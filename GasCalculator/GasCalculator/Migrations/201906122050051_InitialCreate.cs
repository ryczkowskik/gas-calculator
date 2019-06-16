namespace GasCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// Migracja tworz�ca tabel� Gases w bazie danych
    /// </summary>
    public partial class InitialCreate : DbMigration
    {
        /// <summary>
        /// Metoda wykonuj�ca migracj�
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Gases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Factor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DGW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GGW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Consistency = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        /// <summary>
        /// Metoda wycofuj�ca migracj�
        /// </summary>
        public override void Down()
        {
            DropTable("dbo.Gases");
        }
    }
}
