using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.Models
{
    // DbContext = Unit of Work
    public class FlowersDbContext : DbContext
    {
        public FlowersDbContext(DbContextOptions<FlowersDbContext> options) : base(options)
        {
        }

        // DbSet = Repository
        // DbSet = O tabela din baza de date
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
