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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(u => u.Username).IsUnique();
            });
        }

        // DbSet = Repository
        // DbSet = O tabela din baza de date
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
