using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
