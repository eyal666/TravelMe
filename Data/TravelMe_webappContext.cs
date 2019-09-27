using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelMe_webapp.Models
{
    public class TravelMe_webappContext : DbContext
    {
        public TravelMe_webappContext (DbContextOptions<TravelMe_webappContext> options)
            : base(options)
        {
        }

        public DbSet<TravelMe_webapp.Models.Place> Place { get; set; }
    }
}
