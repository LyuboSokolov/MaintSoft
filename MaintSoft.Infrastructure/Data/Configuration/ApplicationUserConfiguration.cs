using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(new ApplicationUser()
            {
                Id = "1",
                UserName = "pecata",
                Email = "petko@abv.bg",
                FirstName = "Petko",
                LastName = "Petkov",
                JobPosition = "maintenance technician"
            });
        }
    }
}
