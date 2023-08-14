using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MaintSoft.Areas.Admin.Models
{
    public class UserEditModel
    {

        public string Id { get; set; }
       
        public string? UserName { get; set; } 


        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; } = null!;

        
        public string? Email { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string JobPosition { get; set; } = null!;

        public string RoleName { get; set; } = null!;

        public List<IdentityRole>? AllRoles { get; set; }
    }
}
