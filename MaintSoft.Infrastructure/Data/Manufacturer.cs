using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class Manufacturer
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 7)]
        public string VAT { get; set; } = null!;

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Contacts { get; set; } = null!;

        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Address { get; set; } = null!;

        [Required]
        public bool IsDelete { get; set; } = false;


        [MaxLength(200)]
        public string? Description { get; set; }

        public List<SparePart> SpareParts { get; set; }

        [Required]
        [MaxLength(256)]
        public string UserCreatedId { get; set; } = null!;

        [MaxLength(256)]
        public string? UserDeletedId { get; set; }


    }
}
