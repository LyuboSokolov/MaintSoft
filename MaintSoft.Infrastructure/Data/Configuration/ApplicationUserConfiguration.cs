using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaintSoft.Infrastructure.Data.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {


        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
        }
        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {

                Id = "1",
                UserName = "lyubo",
                Email = "lubo@abv.bg",
                FirstName = "Lyubo",
                LastName = "Sokolov",
                JobPosition = "Manager",
                NormalizedUserName = "lubo",
                NormalizedEmail = "lubo@abv.bg",
                IsDelete =false
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "12345r");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "2",
                UserName = "Ivan",
                Email = "ivan@abv.bg",
                FirstName = "Ivan",
                LastName = "Ivanov",
                JobPosition = "Engineer",
                NormalizedUserName = "ivan",
                NormalizedEmail = "ivan@abv.bg",
                IsDelete =false
            };

            user.PasswordHash =
            hasher.HashPassword(user, "12345r");

            users.Add(user);

            return users;
        }
    }
}
