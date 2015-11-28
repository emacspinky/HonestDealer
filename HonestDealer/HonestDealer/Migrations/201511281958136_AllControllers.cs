namespace HonestDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllControllers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automobiles",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        Year = c.Int(nullable: false),
                        Transmission = c.String(),
                        Mpg = c.Single(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Body_type = c.String(),
                        Price = c.Int(nullable: false),
                        Damaged_flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Vin);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Mech_name = c.String(nullable: false, maxLength: 128),
                        Dealer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mech_name, t.Dealer_id })
                .ForeignKey("dbo.Dealerships", t => t.Dealer_id, cascadeDelete: true)
                .ForeignKey("dbo.Mechanics", t => t.Mech_name, cascadeDelete: true)
                .Index(t => t.Mech_name)
                .Index(t => t.Dealer_id);
            
            CreateTable(
                "dbo.Mechanics",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Rating = c.Single(nullable: false),
                        Phone_number = c.String(),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Damaged_Automobile",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        Part_name = c.String(nullable: false, maxLength: 128),
                        Location = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Vin, t.Part_name, t.Location })
                .ForeignKey("dbo.Automobiles", t => t.Vin, cascadeDelete: true)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.Dealer_Sells",
                c => new
                    {
                        Dealer_id = c.Int(nullable: false),
                        Vin = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Dealer_id, t.Vin })
                .ForeignKey("dbo.Automobiles", t => t.Vin, cascadeDelete: true)
                .ForeignKey("dbo.Dealerships", t => t.Dealer_id, cascadeDelete: true)
                .Index(t => t.Dealer_id)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.Dealership_Phone",
                c => new
                    {
                        Dealer_id = c.Int(nullable: false),
                        Phone_number = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Dealer_id, t.Phone_number })
                .ForeignKey("dbo.Dealerships", t => t.Dealer_id, cascadeDelete: true)
                .Index(t => t.Dealer_id);
            
            CreateTable(
                "dbo.Employs",
                c => new
                    {
                        Dealer_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dealer_id, t.Employee_id })
                .ForeignKey("dbo.Dealerships", t => t.Dealer_id, cascadeDelete: true)
                .ForeignKey("dbo.Salesmen", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Dealer_id)
                .Index(t => t.Employee_id);
            
            CreateTable(
                "dbo.Salesmen",
                c => new
                    {
                        Employee_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Single(nullable: false),
                        Salary = c.Int(nullable: false),
                        Phone_number = c.String(),
                        Available_appts = c.Int(nullable: false),
                        Used_flag = c.Boolean(nullable: false),
                        New_flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Employee_id);
            
            CreateTable(
                "dbo.Exterior_Color",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        Color = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Vin, t.Color })
                .ForeignKey("dbo.Automobiles", t => t.Vin, cascadeDelete: true)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.Interior_Color",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        Color = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Vin, t.Color })
                .ForeignKey("dbo.Automobiles", t => t.Vin, cascadeDelete: true)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.New_Automobile",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        Manuf_warranty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Vin)
                .ForeignKey("dbo.Automobiles", t => t.Vin)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.New_Sells",
                c => new
                    {
                        Employee_id = c.Int(nullable: false),
                        Vin = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Employee_id, t.Vin })
                .ForeignKey("dbo.Automobiles", t => t.Vin, cascadeDelete: true)
                .ForeignKey("dbo.Salesmen", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Employee_id)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.Previous_Owner",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        Phone_number = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Vin, t.Phone_number })
                .ForeignKey("dbo.Automobiles", t => t.Vin, cascadeDelete: true)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.Used_Automobile",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        Number_of_repairs = c.Int(nullable: false),
                        Dealer_warranty = c.Int(nullable: false),
                        Number_of_owners = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Vin)
                .ForeignKey("dbo.Automobiles", t => t.Vin)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.Used_Sells",
                c => new
                    {
                        Employee_id = c.Int(nullable: false),
                        Vin = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Employee_id, t.Vin })
                .ForeignKey("dbo.Automobiles", t => t.Vin, cascadeDelete: true)
                .ForeignKey("dbo.Salesmen", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Employee_id)
                .Index(t => t.Vin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Used_Sells", "Employee_id", "dbo.Salesmen");
            DropForeignKey("dbo.Used_Sells", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.Used_Automobile", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.Previous_Owner", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.New_Sells", "Employee_id", "dbo.Salesmen");
            DropForeignKey("dbo.New_Sells", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.New_Automobile", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.Interior_Color", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.Exterior_Color", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.Employs", "Employee_id", "dbo.Salesmen");
            DropForeignKey("dbo.Employs", "Dealer_id", "dbo.Dealerships");
            DropForeignKey("dbo.Dealership_Phone", "Dealer_id", "dbo.Dealerships");
            DropForeignKey("dbo.Dealer_Sells", "Dealer_id", "dbo.Dealerships");
            DropForeignKey("dbo.Dealer_Sells", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.Damaged_Automobile", "Vin", "dbo.Automobiles");
            DropForeignKey("dbo.Contracts", "Mech_name", "dbo.Mechanics");
            DropForeignKey("dbo.Contracts", "Dealer_id", "dbo.Dealerships");
            DropIndex("dbo.Used_Sells", new[] { "Vin" });
            DropIndex("dbo.Used_Sells", new[] { "Employee_id" });
            DropIndex("dbo.Used_Automobile", new[] { "Vin" });
            DropIndex("dbo.Previous_Owner", new[] { "Vin" });
            DropIndex("dbo.New_Sells", new[] { "Vin" });
            DropIndex("dbo.New_Sells", new[] { "Employee_id" });
            DropIndex("dbo.New_Automobile", new[] { "Vin" });
            DropIndex("dbo.Interior_Color", new[] { "Vin" });
            DropIndex("dbo.Exterior_Color", new[] { "Vin" });
            DropIndex("dbo.Employs", new[] { "Employee_id" });
            DropIndex("dbo.Employs", new[] { "Dealer_id" });
            DropIndex("dbo.Dealership_Phone", new[] { "Dealer_id" });
            DropIndex("dbo.Dealer_Sells", new[] { "Vin" });
            DropIndex("dbo.Dealer_Sells", new[] { "Dealer_id" });
            DropIndex("dbo.Damaged_Automobile", new[] { "Vin" });
            DropIndex("dbo.Contracts", new[] { "Dealer_id" });
            DropIndex("dbo.Contracts", new[] { "Mech_name" });
            DropTable("dbo.Used_Sells");
            DropTable("dbo.Used_Automobile");
            DropTable("dbo.Previous_Owner");
            DropTable("dbo.New_Sells");
            DropTable("dbo.New_Automobile");
            DropTable("dbo.Interior_Color");
            DropTable("dbo.Exterior_Color");
            DropTable("dbo.Salesmen");
            DropTable("dbo.Employs");
            DropTable("dbo.Dealership_Phone");
            DropTable("dbo.Dealer_Sells");
            DropTable("dbo.Damaged_Automobile");
            DropTable("dbo.Mechanics");
            DropTable("dbo.Contracts");
            DropTable("dbo.Automobiles");
        }
    }
}
