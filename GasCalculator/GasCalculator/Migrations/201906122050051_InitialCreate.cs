namespace GasCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
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
        
        public override void Down()
        {
            DropTable("dbo.Gases");
        }
    }
}
