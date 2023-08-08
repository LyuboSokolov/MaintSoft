using MaintSoft.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MaintSoft.Infrastructure.Data
{
    public class MaintSoftDbContext : IdentityDbContext<ApplicationUser>
    {
        public MaintSoftDbContext(DbContextOptions<MaintSoftDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUserAppTask> ApplicationUsersAppTasks { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<MachineAppTask> MachinesAppTasks { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<SparePart> SpareParts { get; set; }

        public DbSet<AppTask> AppTasks { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserAppTask>()
                .HasKey(k => new { k.ApplicationUserId, k.AppTaskId });

            builder.Entity<ApplicationUserAppTask>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(x => x.ApplicationUserAppTasks)
                .HasForeignKey(x => x.ApplicationUserId);

            builder.Entity<ApplicationUserAppTask>()
                .HasOne(x => x.AppTask)
                .WithMany(x => x.ApplicationUsersAppTasks)
                .HasForeignKey(x => x.AppTaskId);

            builder.Entity<MachineAppTask>()
                .HasKey(k => new { k.MachineId, k.AppTaskId });

            builder.Entity<MachineAppTask>()
                .HasOne(x => x.Machine)
                .WithMany(x => x.MachineAppTasks)
                .HasForeignKey(x => x.MachineId);

            builder.Entity<MachineAppTask>()
                .HasOne(x => x.AppTask)
                .WithMany(x => x.MachinesAppTasks)
                .HasForeignKey(x => x.AppTaskId);


            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<ApplicationUser>()
               .Property(u => u.Email)
               .HasMaxLength(70)
               .IsRequired();

            //builder.Entity<Machine>()
            //    .HasIndex(n => n.Name)
            //    .IsUnique();

            builder.ApplyConfiguration(new StatusConfiguration());

            builder.ApplyConfiguration(new ApplicationUserConfiguration());

            builder.ApplyConfiguration(new AssetConfiguration());

            builder.ApplyConfiguration(new MachineConfiguration());

            builder.ApplyConfiguration(new AppTaskConfiguration());

            builder.ApplyConfiguration(new ManufacturerConfiguration());

            builder.ApplyConfiguration(new SparePartConfiguration());

            builder.ApplyConfiguration(new ApplicationUserAppTaskConfiguration());

            builder.ApplyConfiguration(new MachineAppTaskConfiguration());


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "Administrator", ConcurrencyStamp = "e821c43e-236a-4615-a454-7af10dd382e3", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole() { Id = "2", Name = "Engineer", ConcurrencyStamp = "c20198be-88e7-48e8-a58f-920717c23954", NormalizedName = "ENGINEER" },
                new IdentityRole() { Id = "3", Name = "Operator", ConcurrencyStamp = "f4124e32-6f00-4b83-895f-d50317234f01", NormalizedName = "Operator" },
                new IdentityRole() { Id = "4", Name = "User", ConcurrencyStamp = "ba2e85bb-669f-404a-bfe1-b479b75098a9", NormalizedName = "USER" }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>() { RoleId = "1", UserId = "1" }
               );

            builder.Entity<IdentityUserRole<string>>().HasData(
              new IdentityUserRole<string>() { RoleId = "3", UserId = "2" }
              );

        }
    }
}