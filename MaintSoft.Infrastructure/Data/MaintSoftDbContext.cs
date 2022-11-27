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

        public DbSet<ApplicationUserTask> ApplicationUsersTasks { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<MachineTask> MachinesTasks { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<SparePart> SpareParts { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserTask>()
                .HasKey(k => new { k.ApplicationUserId, k.TaskId });

            builder.Entity<MachineTask>()
                .HasKey(k => new { k.MachineId, k.TaskId });

        }
    }
}