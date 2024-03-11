using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.entity;
using Microsoft.EntityFrameworkCore;

namespace application.common.interfaces
{
    public interface IAppDbContext
    {
        
        public DbSet<User> Users {get; set;}
        public DbSet<Barang> Barangs { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}