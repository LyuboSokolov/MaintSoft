using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string UserName { get; set; } = null!;


        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(70, MinimumLength = 4)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string JobPosition { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


    }
}
