using MaoDeVaca.Domain.Entities;
using MaoDeVaca.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaoDeVaca.Infra
{
    public class MaoDeVacaDbContext : DbContext
    {
        public MaoDeVacaDbContext(DbContextOptions<MaoDeVacaDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMapping(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
