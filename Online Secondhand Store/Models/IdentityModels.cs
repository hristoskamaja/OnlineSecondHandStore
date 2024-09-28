using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Online_Secondhand_Store.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

        public System.Data.Entity.DbSet<Online_Secondhand_Store.Models.Car> Cars { get; set; }

        public System.Data.Entity.DbSet<Online_Secondhand_Store.Models.Clothing> Clothings { get; set; }

        public System.Data.Entity.DbSet<Online_Secondhand_Store.Models.ComputerAndITEquipment> ComputerAndITEquipments { get; set; }

        public System.Data.Entity.DbSet<Online_Secondhand_Store.Models.ElectricalAppliance> ElectricalAppliances { get; set; }

        public System.Data.Entity.DbSet<Online_Secondhand_Store.Models.Furniture> Furnitures { get; set; }
    }
}