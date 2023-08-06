using MaintSoft.Infrastructure.Data.Configuration;
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

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
        }
    }
}