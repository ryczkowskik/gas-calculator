namespace GasCalculator.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Konfiguracja migracji Entity Framework 
    /// </summary>
    public sealed class Configuration : DbMigrationsConfiguration<GasCalculator.Storage.DataContext>
    {
        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Metoda wywo³ywana po ostatniej migracji
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(GasCalculator.Storage.DataContext context)
        {
        }
    }
}
