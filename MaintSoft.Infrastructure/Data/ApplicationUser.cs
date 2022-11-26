using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(70, MinimumLength = 4)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string JobPosition { get; set; } = null!;

        [Required]
        public bool IsDelete { get; set; } = false;

        public List<ApplicationUserTask> ApplicationUserTasks { get; set; }

    }
}
