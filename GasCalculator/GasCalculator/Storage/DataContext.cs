using GasCalculator.Entities;
using GasCalculator.Migrations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GasCalculator.Storage
{
    public class DataContext : DbContext
    {
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DataContext() : this("GasCalculatorContext") { }

        public DbSet<Gas> Gases { get; set; }

        internal static List<string> GetPendingMigrations()
        {
            var configuration = new Configuration();
            configuration.TargetDatabase = new DbConnectionInfo(System.Configuration.ConfigurationManager.ConnectionStrings["GasCalculatorContext"].ConnectionString, "System.Data.SqlServerCE.4.0");
            var dbMigrator = new DbMigrator(configuration);

            return dbMigrator.GetPendingMigrations().ToList();
        }

        internal static void UpdateDatabase()
        {
            var configuration = new Configuration();
            configuration.TargetDatabase = new DbConnectionInfo(System.Configuration.ConfigurationManager.ConnectionStrings["GasCalculatorContext"].ConnectionString, "System.Data.SqlServerCE.4.0");
            var dbMigrator = new DbMigrator(configuration);
            dbMigrator.Update();
        }
    }
}
