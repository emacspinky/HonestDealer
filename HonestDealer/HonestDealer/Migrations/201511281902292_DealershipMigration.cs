namespace HonestDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealershipMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dealerships",
                c => new
                    {
                        Dealer_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Web_address = c.String(),
                        Makes_sold = c.String(),
                        Dealer_rating = c.Single(nullable: false),
                        Car_count = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Open_time = c.String(),
                        Close_time = c.String(),
                    })
                .PrimaryKey(t => t.Dealer_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dealerships");
        }
    }
}
