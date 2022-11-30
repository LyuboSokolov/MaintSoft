using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserAppTask>()
                .HasKey(k => new { k.ApplicationUserId, k.TaskId });

            builder.Entity<MachineAppTask>()
                .HasKey(k => new { k.MachineId, k.TaskId });


            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<ApplicationUser>()
               .Property(u => u.Email)
               .HasMaxLength(70)
               .IsRequired();
        }
    }
}