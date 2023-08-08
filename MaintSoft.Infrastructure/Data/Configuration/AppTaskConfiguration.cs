using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class AppTaskConfiguration : IEntityTypeConfiguration<AppTask>
    {
        public void Configure(EntityTypeBuilder<AppTask> builder)
        {
            builder.HasData(new AppTask()
            {
                Id = 1,
                Name = "broken clutch",
                Description = "Repair clutch",
                IsDelete = false,
                UserContractorId = "1",
                UserCreatedId = "1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                StatusId = 1,
                MachinesAppTasks =new List<MachineAppTask>()
            },
            new AppTask()
            {
                Id = 2,
                Name = "broken contactor",
                Description = "Repair contactor",
                IsDelete = false,
                UserContractorId = "2",
                UserCreatedId = "1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                StatusId = 2,
               // MachinesAppTasks = new List<MachineAppTask>() { new Machine() { Id =1 } }
            });
        }
    }
}
