using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR.Pipeline;
using MediatR;
using Sheekr.Application.Infrastructure;
using Sheekr.Application.Escola.Alunos.Command;
using Sheekr.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using NSwag.AspNetCore;

namespace Sheekr.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Adicionando a Pipeline do MediatR           
            AddMediatR(services);

            //Adicionando o DbContext
            services.AddDbContext<SheekrDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SheekrDatabase")));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<CriarAlunoCommand>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerDocument();
            //services.AddSwaggerGen(config =>
            //{
            //    config.SwaggerDoc("v1", new Info { Title = "Sheekr API", Version = "v1" });
            //});

            //services.AddNodeServices(options =>
            //{
            //    options.ProjectPath = "clientapp";
            //});

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "clientapp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                }
            });
        }

        public static void AddMediatR(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));

            var assembly = typeof(CriarAlunoCommand).GetType().Assembly;

            AssemblyScanner.FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddMediatR(typeof(CriarAlunoCommand).GetTypeInfo().Assembly);
        }
    }
}
