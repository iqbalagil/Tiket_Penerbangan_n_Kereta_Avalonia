using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Penumpang> Penumpang { get; set; }
    public DbSet<Pemesanan> Pemesanan { get; set; }
    public DbSet<Petugas> Petugas { get; set; }
    public DbSet<Rute> Rute { get; set; }
    public DbSet<Roles> Role { get; set; }
    public DbSet<Transportasi> Transportasi { get; set; }
    public DbSet<TypeTransportasi> TypeTransportasi { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"DataSource=E:\Project\PenerbanganApplication\Penerbangan.db");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Penumpang>()
            .HasOne(r => r.Role)
            .WithMany(p => p.Penumpangs)
            .HasForeignKey(fk => fk.IdRole);

        builder.Entity<Petugas>()
            .HasOne(r => r.Roles)
            .WithMany(p => p.Petugas)
            .HasForeignKey(fk => fk.idRole);

        builder.Entity<Pemesanan>()
            .HasOne(p => p.Petugas)
            .WithMany(p => p.Pemesanans)
            .HasForeignKey(fk => fk.idPetugas);

        builder.Entity<Pemesanan>()
            .HasOne(r => r.Tujuan)
            .WithMany(p => p.Pemesanans)
            .HasForeignKey(fk => fk.IdRute);

        builder.Entity<Pemesanan>()
            .HasOne(p => p.Penumpang)
            .WithMany(p => p.Pemesanans)
            .HasForeignKey(fk => fk.idPenumpang);

        builder.Entity<Transportasi>()
            .HasOne(t => t.TypeTransportasi)
            .WithMany(k => k.Transports)
            .HasForeignKey(fk => fk.IdTypeTransportasi);

        builder
            .Entity<Transportasi>()
            .Property(k => k.Keterangan)
            .IsRequired()
            .HasDefaultValue("Active");

        builder
            .Entity<Penumpang>()
            .Property(p => p.Username)
            .IsRequired();

        builder.Entity<Penumpang>()
            .Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Entity<Penumpang>()
            .Property(p => p.Password)
            .IsRequired();
    }
}