using Microsoft.EntityFrameworkCore;
using Register_Agen.Model;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Registration> Registrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Registration>()
            .Property(r => r.GPA)
            .HasColumnType("decimal(18, 2)");

        // Sisipkan konfigurasi lain di sini jika diperlukan
    }
}

