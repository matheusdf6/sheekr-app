using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Sheekr.Data
{
    public class SheekrDbContextFactory : IDesignTimeDbContextFactory<SheekrDbContext>
    {
        public const string ConnectionStringName = "SheekrDatabase";
        public const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        protected SheekrDbContext CreateNewInstance(DbContextOptions<SheekrDbContext> options)
        {
            return new SheekrDbContext(options);
        }

        public SheekrDbContext CreateDbContext(string[] args)
        {
            try
            {
                var basePath = @"C:\Users\mathe\source\repos\Sheekr\Sheekr.Tests.Console"; //Directory.GetCurrentDirectory() + string.Format("{0}..{0}Sheekr.Tests.Console", Path.DirectorySeparatorChar);
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

        private SheekrDbContext Create(string basePath, string environmentName)
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

        private SheekrDbContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<SheekrDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
