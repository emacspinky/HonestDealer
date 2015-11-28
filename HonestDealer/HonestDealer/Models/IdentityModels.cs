using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HonestDealer.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HonestDealer.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Dealership> Dealerships { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Dealership_Phone> Dealership_Phone { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Employs> Employs { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Salesman> Salesmen { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.New_Sells> New_Sells { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Automobile> Automobiles { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Used_Sells> Used_Sells { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Contracts> Contracts { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Mechanic> Mechanics { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Dealer_Sells> Dealer_Sells { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Interior_Color> Interior_Color { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Exterior_Color> Exterior_Color { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.New_Automobile> New_Automobile { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Used_Automobile> Used_Automobile { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Damaged_Automobile> Damaged_Automobile { get; set; }

        public System.Data.Entity.DbSet<HonestDealer.Models.Previous_Owner> Previous_Owner { get; set; }
    }
}