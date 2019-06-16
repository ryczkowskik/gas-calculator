using GasCalculator.Entities;
using GasCalculator.Migrations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GasCalculator.Storage
{
    /// <summary>
    /// Kontekst bazy danych poprzez który możliwy jest dostęp do bazy danych
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        /// <param name="nameOrConnectionString">Ciąg połączeniowy do bazy danych</param>
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        public DataContext() : this("GasCalculatorContext") { }

        /// <summary>
        /// Właściwość umożliwiająca dostęp do encji Gas w bazie danych
        /// </summary>
        public DbSet<Gas> Gases { get; set; }

        /// <summary>
        /// Metoda sprawdza czy istnieją jakieś migracje aktualizujące bazę danych
        /// </summary>
        /// <returns></returns>
        internal static List<string> GetPendingMigrations()
        {
            var configuration = new Configuration();
            configuration.TargetDatabase = new DbConnectionInfo(System.Configuration.ConfigurationManager.ConnectionStrings["GasCalculatorContext"].ConnectionString, "System.Data.SqlServerCE.4.0");
            var dbMigrator = new DbMigrator(configuration);

            return dbMigrator.GetPendingMigrations().ToList();
        }

        /// <summary>
        /// Metoda aktualizuje bazę danych
        /// </summary>
        internal static void UpdateDatabase()
        {
            var configuration = new Configuration();
            configuration.TargetDatabase = new DbConnectionInfo(System.Configuration.ConfigurationManager.ConnectionStrings["GasCalculatorContext"].ConnectionString, "System.Data.SqlServerCE.4.0");
            var dbMigrator = new DbMigrator(configuration);
            dbMigrator.Update();
        }
    }
}
