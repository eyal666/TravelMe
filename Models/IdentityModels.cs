using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelMe.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Disable { get; set; }
        public int MembershipTypeId { get; set; }

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

        public System.Data.Entity.DbSet<TravelMe_webapp.Models.Place> Places { get; set; }

        public System.Data.Entity.DbSet<TravelMe_webapp.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<TravelMe_webapp.Models.Comments> Comments { get; set; }

        public System.Data.Entity.DbSet<TravelMe_webapp.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<TravelMe_webapp.Models.PlaceCatagory> PlaceCatagories { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }
    }
}