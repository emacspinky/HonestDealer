namespace HonestDealer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HonestDealer.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<HonestDealer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(HonestDealer.Models.ApplicationDbContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.
        //    //
        //    //    context.People.AddOrUpdate(
        //    //      p => p.FullName,
        //    //      new Person { FullName = "Andrew Peters" },
        //    //      new Person { FullName = "Brice Lambson" },
        //    //      new Person { FullName = "Rowan Miller" }
        //    //    );
        //    //
        //}

        bool AddUserAndRole(HonestDealer.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(HonestDealer.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Contacts.AddOrUpdate(p => p.Name,
               new Contact
               {
                   Name = "Debra Garcia",
                   Address = "1234 Main St",
                   City = "Redmond",
                   State = "WA",
                   Zip = "10999",
                   Email = "debra@example.com",
               },
                new Contact
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "thorsten@example.com",
                },
                new Contact
                {
                    Name = "Yuhong Li",
                    Address = "9012 State st",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "yuhong@example.com",
                },
                new Contact
                {
                    Name = "Jon Orton",
                    Address = "3456 Maple St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "jon@example.com",
                },
                new Contact
                {
                    Name = "Diliana Alexieva-Bosseva",
                    Address = "7890 2nd Ave E",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "diliana@example.com",
                }
                );

            context.Automobiles.AddOrUpdate(p => p.Vin,
                new Automobile
                {

                    Vin = "12345678901234567",
                    Year = 2011,
                    Transmission = "Manual",
                    Mpg = 20,
                    Make = "Ford",
                    Model = "Focus",
                    Body_type = "Sedan",
                    Price = 50000,
                    Damaged_flag = false,
                },
                new Automobile
                {

                    Vin = "1A1A1A1A1A1A1A1A1",
                    Year = 2011,
                    Transmission = "Auto",
                    Mpg = 15,
                    Make = "Dodge",
                    Model = "Ram",
                    Body_type = "Truck",
                    Price = 20000,
                    Damaged_flag = false,
                },
                new Automobile
                {

                    Vin = "ABC123ABC123ABC12",
                    Year = 2013,
                    Transmission = "Auto",
                    Mpg = 26,
                    Make = "Chevy",
                    Model = "Cobalt",
                    Body_type = "Sedan",
                    Price = 40000,
                    Damaged_flag = false,
                },
                new Automobile
                {

                    Vin = "C1C2C3C4C5C6C7C8C",
                    Year = 2012,
                    Transmission = "Manual",
                    Mpg = 22,
                    Make = "Toyota",
                    Model = "Camery",
                    Body_type = "Sedan",
                    Price = 35000,
                    Damaged_flag = true,
                },
                new Automobile
                {

                    Vin = "09876543210987654",
                    Year = 2001,
                    Transmission = "Auto",
                    Mpg = 13,
                    Make = "Mittsubishi",
                    Model = "Galant",
                    Body_type = "Sedan",
                    Price = 5000,
                    Damaged_flag = true,
                }
                );

            context.Damaged_Automobile.AddOrUpdate(p => p.Vin,
                new Damaged_Automobile
                {

                    Vin = "C1C2C3C4C5C6C7C8C",
                    Part_name = "Hyper Overdrive",
                    Location = "Engine",
                },
                new Damaged_Automobile
                {
                    Vin = "09876543210987654",
                    Part_name = "Wipers",
                    Location = "Windshield",
                }
                );

            context.Dealerships.AddOrUpdate(p => p.Name,
                new Dealership
                {
                    Dealer_id = 1,
                    Name = "Kingdom Kia",
                    Web_address = "http://www.kingdomkia.com/",
                    Makes_sold = "Kia",
                    Dealer_rating = 4,
                    Car_count = 400,
                    Username = "KKia",
                    Password = "kingdom",
                    Open_time = "9:00am",
                    Close_time = "5:00pm",
                },
                new Dealership
                {
                    Dealer_id = 2,
                    Name = "Denny Ford",
                    Web_address = "http://www.dennyford.com/",
                    Makes_sold = "Ford,Lincoln, Mercury",
                    Dealer_rating = 5,
                    Car_count = 600,
                    Username = "DFord",
                    Password = "625west",
                    Open_time = "8:00am",
                    Close_time = "5:00pm",
                },
                new Dealership
                {
                    Dealer_id = 3,
                    Name = "Al West",
                    Web_address = "http://alwest.com/",
                    Makes_sold = "Nissan, Chrysler, Dodge, Jeep, Ram",
                    Dealer_rating = 3,
                    Car_count = 1000,
                    Username = "AWest",
                    Password = "awag",
                    Open_time = "9:00am",
                    Close_time = "4:00pm",
                },
                new Dealership
                {
                    Dealer_id = 4,
                    Name = "Fairground Auto Plaza",
                    Web_address = "http://fairchev.com/",
                    Makes_sold = "Chevy, Buick, GMC,Cadillac",
                    Dealer_rating = 4,
                    Car_count = 200,
                    Username = "FairAP",
                    Password = "fairchev",
                    Open_time = "10:00am",
                    Close_time = "5:00pm",
                }
                );


            context.New_Automobile.AddOrUpdate(p => p.Vin,
                new New_Automobile
                {
                    Vin = "ABC123ABC123ABC12",
                    Manuf_warranty = 1,
                },
                new New_Automobile
                {
                    Vin = "1A1A1A1A1A1A1A1A1",
                    Manuf_warranty = 2,
                }
                );

            context.Used_Automobile.AddOrUpdate(p => p.Vin,
                new Used_Automobile
                {
                    Vin = "12345678901234567",
                    Mileage = 20000,
                    Dealer_warranty = 1,
                    Number_of_owners = 2,
                    Number_of_repairs = 2,
                }
                );

            context.Mechanics.AddOrUpdate(p => p.Name,
                new Mechanic
                {
                    Name = "Johnny Fix",
                    Phone_number = "2408888",
                    Rating = 2,
                    Salary = 30000,
                },

                new Mechanic
                {
                    Name = "Guy Dorand",
                    Phone_number = "5349872",
                    Rating = 3,
                    Salary = 45000,
                },

                new Mechanic
                {
                    Name = "Frank Olap",
                    Phone_number = "6451234",
                    Rating = 4,
                    Salary = 60000,
                },

                new Mechanic
                {
                    Name = "Trell Omane",
                    Phone_number = "2258999",
                    Rating = 1,
                    Salary = 20000,
                },

                new Mechanic
                {
                    Name = "Ronda Spare",
                    Phone_number = "8675309",
                    Rating = 3,
                    Salary = 32000,
                }
                );

            context.Salesmen.AddOrUpdate(p => p.Name,
                new Salesman
                {
                    Employee_id = 1234567,
                    Name = "Joel Percyman",
                    Rating = 4,
                    Salary = 80000,
                    Phone_number = "2338423",
                    Available_appts = 6,
                    Used_flag = true,
                    New_flag = false,
                },
                new Salesman
                {
                    Employee_id = 8675309,
                    Name = "Dan Lin",
                    Rating = 5,
                    Salary = 100000,
                    Phone_number = "6842396",
                    Available_appts = 1,
                    Used_flag = false,
                    New_flag = true,
                },
                new Salesman
                {
                    Employee_id = 3752107,
                    Name = "Scott Bierpercy",
                    Rating = 3,
                    Salary = 40000,
                    Phone_number = "3726851",
                    Available_appts = 3,
                    Used_flag = true,
                    New_flag = false,
                },
                new Salesman
                {
                    Employee_id = 2957482,
                    Name = "Tyler Perrybaum",
                    Rating = 4,
                    Salary = 60000,
                    Phone_number = "3210987",
                    Available_appts = 4,
                    Used_flag = false,
                    New_flag = true,
                }
                );
        }
    }
}
