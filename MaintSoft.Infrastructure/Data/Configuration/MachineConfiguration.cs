using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class MachineConfiguration : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasData(new Machine()
            {
                Id = 1,
                Name = "Final Assembly",
                Code = "GHW1_221_314",
                Description = "for mcb",
                IsDelete = false,
                Location = "Desto",
                UserCreatedId = "1",
                ImageUrl = "https://teeptrak.com/wp-content/uploads/2020/10/TRS-mesurervotreperformancemachine-scaled.jpeg"

            },
            new Machine()
            {

                Id = 2,
                Name = "Magnetic Test",
                Code = "GHW1_386_441",
                Description = "Magnetic tester for MCB",
                IsDelete = false,
                Location = "Desto",
                UserCreatedId = "2",
                ImageUrl = "https://img.directindustry.com/images_di/photo-g/19857-14864675.webp"
            },
             new Machine()
             {

                 Id = 3,
                 Name = "Thermal Test",
                 Code = "GHW2_386_441",
                 Description = "Thermal tester for MCB",
                 IsDelete = false,
                 Location = "Desto",
                 UserCreatedId = "1",
                 ImageUrl = "https://img.directindustry.com/images_di/photo-mg/19857-17472673.jpg"
             });
        }
    }
}
