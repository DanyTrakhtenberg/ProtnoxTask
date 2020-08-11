using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ProtnoxDbContext : DbContext
    {

        public DbSet<NetworkEvent> NetworkEvents { get; set; }

        public ProtnoxDbContext(DbContextOptions<ProtnoxDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NetworkEvent>().HasKey(e => e.Event_id);

        }
    }
}

