using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasData(new Asset()
            {
                Id = 1,
                Name = "Laptop_p50",
                Description = "Workstation",
                IsDelete = false,
                ApplicationUserId = "2",
                UserCreatedId = "2",
                IsAvailable = true
            },
            new Asset()
            {
                Id = 2,
                Name = "Samsung_s20",
                Description = "smartphone",
                IsDelete = false,
                ApplicationUserId = "2",
                UserCreatedId = "2",
                IsAvailable = true
            });
        }
    }
}
