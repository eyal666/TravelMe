using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelMe_webapp.Models;

namespace TravelMe_webapp.Models
{
    public class TravelMe_webappContext : DbContext
    {
        public TravelMe_webappContext (DbContextOptions<TravelMe_webappContext> options)
            : base(options)
        {
        }

        public DbSet<TravelMe_webapp.Models.Place> Place { get; set; }

        public DbSet<TravelMe_webapp.Models.Post> Post { get; set; }

        public DbSet<TravelMe_webapp.Models.Category> Category { get; set; }

        public DbSet<TravelMe_webapp.Models.User> User { get; set; }

        public DbSet<TravelMe_webapp.Models.Comments> Comments { get; set; }

        public DbSet<TravelMe_webapp.Models.PlaceCatagory> PlaceCatagory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }

    }
}
