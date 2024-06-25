using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using Planifi_backend.DataEntry.Domain.Model.Entities;
using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Planifi_backend.Workers.Domain.Model.Aggregates;

namespace Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Place here your entities configuration

        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);

        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Business,
            b =>
            {
                b.WithOwner().HasForeignKey("Id");
                b.Property(s => s.businessName).HasColumnName("BusinessName");
            });

        builder.Entity<Worker>().HasKey(w => w.Id);
        builder.Entity<Worker>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Worker>().OwnsOne(w => w.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(w => w.FirstName).HasColumnName("FirstName");
                n.Property(w => w.LastName).HasColumnName("LastName");
            });
        builder.Entity<Worker>().OwnsOne(w => w.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Value).HasColumnName("EmailAddress");
            });
        builder.Entity<Worker>().Property(w => w.Phone).IsRequired();
        builder.Entity<Worker>().Property(w => w.Address).IsRequired();
        builder.Entity<Worker>().OwnsOne(w => w.WorkInformation,
            w =>
            {
                w.WithOwner().HasForeignKey("Id");
                w.Property(w => w.Position).HasColumnName("Position");
                w.Property(w => w.WorkedHours).HasColumnName("WorkedHours");
                w.Property(w => w.ExtraHours).HasColumnName("ExtraHours");
                w.Property(w => w.Performance).HasColumnName("Performance");
            });
        
        // IAM Context

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}