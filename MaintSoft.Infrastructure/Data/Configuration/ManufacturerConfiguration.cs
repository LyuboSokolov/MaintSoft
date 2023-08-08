using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder) 
        {
            builder.HasData(new Manufacturer()
            {
                Id = 1,
                Name = "Festo",
                VAT = "GB999 99 9991",
                Address = "Germany str.20",
                IsDelete = false,
                Description = "Production of cylinder",
                UserCreatedId = "1",
                Contacts = "+359 000 23 93"
            },
            new Manufacturer()
            {
                Id = 2,
                Name = "Omron",
                VAT = "BG1 232 771",
                Address = "Sofia str.Vasil Levski",
                IsDelete = false,
                Description = "Production of sensor",
                UserCreatedId = "2",
                Contacts = "+402 000 22 93"
            },
             new Manufacturer()
             {
                 Id = 3,
                 Name = "IFM",
                 VAT = "BG1 123 334",
                 Address = "Plovdiv str.Vasil Levski",
                 IsDelete = false,
                 Description = "Production of sensor and scaner",
                 UserCreatedId = "1",
                 Contacts = "+23 11 3345 93"
             });
        }
    }
}
