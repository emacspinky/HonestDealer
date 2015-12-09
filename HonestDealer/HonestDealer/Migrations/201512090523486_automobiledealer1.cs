namespace HonestDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class automobiledealer1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Automobiles", "Dealer_id", "dbo.Dealerships");
            DropIndex("dbo.Automobiles", new[] { "Dealer_id" });
            AlterColumn("dbo.Automobiles", "Dealer_id", c => c.Int(nullable: true));
            CreateIndex("dbo.Automobiles", "Dealer_id");
            AddForeignKey("dbo.Automobiles", "Dealer_id", "dbo.Dealerships", "Dealer_id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automobiles", "Dealer_id", "dbo.Dealerships");
            DropIndex("dbo.Automobiles", new[] { "Dealer_id" });
            AlterColumn("dbo.Automobiles", "Dealer_id", c => c.Int());
            CreateIndex("dbo.Automobiles", "Dealer_id");
            AddForeignKey("dbo.Automobiles", "Dealer_id", "dbo.Dealerships", "Dealer_id");
        }
    }
}
