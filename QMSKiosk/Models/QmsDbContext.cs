using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace QMSKiosk.Models;

public partial class QmsDbContext : DbContext
{

    private string _connectionString;
    //private string _connectionString1;
    //Scaffold-DbContext "Server=DESKTOP-R532NCV\ASADUZZAMAN;Database=qms-db;Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
    public QmsDbContext()
    {
        string[] args = Environment.GetCommandLineArgs().Skip(1).ToArray();
        HostApplicationBuilder builder1 = Host.CreateApplicationBuilder(args);
        _connectionString = builder1.Configuration.GetConnectionString("DefaultConnection");
     
    }


    public QmsDbContext(DbContextOptions<QmsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Desk> Desks { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Refresh> Refreshes { get; set; }

    public virtual DbSet<ServiceInfo> ServiceInfos { get; set; }

    public virtual DbSet<ServiceReceiver> ServiceReceivers { get; set; }

    public virtual DbSet<UserServicesDesk> UserServicesDesks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       //=> optionsBuilder.UseSqlServer("Server=192.168.0.160; User Id=sa; Password=Asad@123; Database=qms-db;Trusted_Connection=false; TrustServerCertificate=True; MultipleActiveResultSets=true;");
       => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasIndex(e => e.CreatedById, "IX_Advertisements_CreatedById");

            entity.HasIndex(e => e.DeletedById, "IX_Advertisements_DeletedById");

            entity.HasIndex(e => e.UpdatedById, "IX_Advertisements_UpdatedById");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.AdvertisementCreatedBies).HasForeignKey(d => d.CreatedById);

            entity.HasOne(d => d.DeletedBy).WithMany(p => p.AdvertisementDeletedBies).HasForeignKey(d => d.DeletedById);

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.AdvertisementUpdatedBies).HasForeignKey(d => d.UpdatedById);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.EmployeeCode).HasDefaultValueSql("(N'')");
            entity.Property(e => e.FullName).HasDefaultValueSql("(N'')");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Desk>(entity =>
        {
            entity.HasIndex(e => e.CreatedById, "IX_Desks_CreatedById");

            entity.HasIndex(e => e.DeletedById, "IX_Desks_DeletedById");

            entity.HasIndex(e => e.UpdatedById, "IX_Desks_UpdatedById");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.DeskCreatedBies).HasForeignKey(d => d.CreatedById);

            entity.HasOne(d => d.DeletedBy).WithMany(p => p.DeskDeletedBies).HasForeignKey(d => d.DeletedById);

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.DeskUpdatedBies).HasForeignKey(d => d.UpdatedById);
        });

        modelBuilder.Entity<ServiceInfo>(entity =>
        {
            entity.ToTable("ServiceInfo");

            entity.HasIndex(e => e.CreatedById, "IX_ServiceInfo_CreatedById");

            entity.HasIndex(e => e.DeletedById, "IX_ServiceInfo_DeletedById");

            entity.HasIndex(e => e.ParentId, "IX_ServiceInfo_ParentId");

            entity.HasIndex(e => e.UpdatedById, "IX_ServiceInfo_UpdatedById");

            entity.Property(e => e.TokenStart).HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.ServiceInfoCreatedBies).HasForeignKey(d => d.CreatedById);

            entity.HasOne(d => d.DeletedBy).WithMany(p => p.ServiceInfoDeletedBies).HasForeignKey(d => d.DeletedById);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasForeignKey(d => d.ParentId);

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.ServiceInfoUpdatedBies).HasForeignKey(d => d.UpdatedById);
        });

        modelBuilder.Entity<ServiceReceiver>(entity =>
        {
            entity.HasIndex(e => e.ServiceInfoId, "IX_ServiceReceivers_ServiceInfoId");

            entity.HasIndex(e => e.ServiceProviderId, "IX_ServiceReceivers_ServiceProviderId");

            entity.Property(e => e.IsClearedFromDisplay)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");

            entity.HasOne(d => d.ServiceInfo).WithMany(p => p.ServiceReceivers).HasForeignKey(d => d.ServiceInfoId);

            entity.HasOne(d => d.ServiceProvider).WithMany(p => p.ServiceReceivers).HasForeignKey(d => d.ServiceProviderId);
        });

        modelBuilder.Entity<UserServicesDesk>(entity =>
        {
            entity.ToTable("UserServicesDesk");

            entity.HasIndex(e => e.AppUserId, "IX_UserServicesDesk_AppUserId");

            entity.HasIndex(e => e.CreatedById, "IX_UserServicesDesk_CreatedById");

            entity.HasIndex(e => e.DeletedById, "IX_UserServicesDesk_DeletedById");

            entity.HasIndex(e => e.DeskId, "IX_UserServicesDesk_DeskId");

            entity.HasIndex(e => e.ServiceInfoId, "IX_UserServicesDesk_ServiceInfoId");

            entity.HasIndex(e => e.UpdatedById, "IX_UserServicesDesk_UpdatedById");

            entity.HasOne(d => d.AppUser).WithMany(p => p.UserServicesDeskAppUsers).HasForeignKey(d => d.AppUserId);

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.UserServicesDeskCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DeletedBy).WithMany(p => p.UserServicesDeskDeletedBies).HasForeignKey(d => d.DeletedById);

            entity.HasOne(d => d.Desk).WithMany(p => p.UserServicesDesks)
                .HasForeignKey(d => d.DeskId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ServiceInfo).WithMany(p => p.UserServicesDesks)
                .HasForeignKey(d => d.ServiceInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UpdatedBy).WithMany(p => p.UserServicesDeskUpdatedBies).HasForeignKey(d => d.UpdatedById);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
