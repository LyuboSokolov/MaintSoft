using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class SparePartConfiguration : IEntityTypeConfiguration<SparePart>
    {
        public void Configure (EntityTypeBuilder<SparePart> builder)
        {
            builder.HasData(new SparePart()
            {
                Id = 1,
                Name = "Cylinder",
                Code = "DSNU-16-20 ADNGF",
                Quantity = 2,
                Description = "Standart cilinder",
                Location = "Desto",
                ManufacturerId = 1,
                IsDelete = false,
                UserCreatedId = "1",
                ImageUrl = "https://ch.farnell.com/productimages/large/en_GB/3431515-40.jpg"
            },
            new SparePart()
            {
                Id = 2,
                Name = "Contactor",
                Code = "ABB 07-10-30",
                Quantity = 1,
                Description = "Standart contactor",
                Location = "Desto",
                ManufacturerId = 1,
                IsDelete = false,
                UserCreatedId = "1",
                ImageUrl = "https://bg.farnell.com/productimages/large/en_GB/1846130-40.jpg"
            });
        }
    }
}
