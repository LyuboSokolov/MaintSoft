using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class ApplicationUserAppTaskConfiguration : IEntityTypeConfiguration<ApplicationUserAppTask>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserAppTask> builder)
        {
            builder.HasData(new ApplicationUserAppTask()
            {
                ApplicationUserId = "1",
                AppTaskId = 1
            },
            new ApplicationUserAppTask()
            {
                ApplicationUserId = "1",
                AppTaskId = 2
            });
        }
    }
}
