using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(new Status()
            {
                Id = 1,
                Name = "New"
            },
            new Status()
            {
                Id = 2,
                Name = "In Process"
            },
            new Status()
            {
                Id = 3,
                Name = "Stopped"
            },
            new Status()
            {
                Id = 4,
                Name = "Done"
            });
        }
    }
}
