using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class MachineAppTaskConfiguration : IEntityTypeConfiguration<MachineAppTask>
    {
        public void Configure(EntityTypeBuilder<MachineAppTask> builder)
        {
            builder.HasData(new MachineAppTask()
            {
                MachineId = 1,
                AppTaskId = 1
            },
            new MachineAppTask()
            {
                MachineId = 1,
                AppTaskId = 2 
            });
        }
    }
}
