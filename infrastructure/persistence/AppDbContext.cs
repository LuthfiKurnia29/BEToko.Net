using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.common.interfaces;
using domain.entity;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Barang> Barangs { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}