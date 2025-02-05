using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Penumpang> Penumpang { get; set; }
        public DbSet<Pemesanan> Pemesanan { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Petugas> Petugas { get; set; }
        public DbSet<Rute> Rute { get; set; }
        public DbSet<Transportasi> Transportasi { get; set; }
        public DbSet<TypeTransportasi> TypeTransportasi { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Data Source=Penerbangan.db");
        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
    
}
