using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Sheekr.Data
{
    public class SheekrIdentityDbContextFactory
        : IDesignTimeDbContextFactory<SheekrIdentityDbContext>
    {
        public const string ConnectionStringName = "IdentityDatabase";
        public const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        protected SheekrIdentityDbContext CreateNewInstance(DbContextOptions<SheekrIdentityDbContext> options)
        {
            return new SheekrIdentityDbContext(options);
        }

        public SheekrIdentityDbContext CreateDbContext(string[] args)
        {
            try
            {
                var basePath = Directory.GetCurrentDirectory(); //+ string.Format("{0}..{0}Sheekr.Data", Path.DirectorySeparatorChar);
                Console.WriteLine(basePath);
                return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar DbContext! " +
                    $"\n Origem do Erro: {ex.TargetSite}" +
                    $"\n Mensagem de Erro: {ex.Message} +" +
                    $"\n StackTrace : {ex.InnerException}");
            }
            return null;
        }

        private SheekrIdentityDbContext Create(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            return Create(connectionString);
        }

        private SheekrIdentityDbContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<SheekrIdentityDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}

