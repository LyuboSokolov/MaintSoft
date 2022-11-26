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

 
        [StringLength(200, MinimumLength = 0)]
        public string Description { get; set; }

        public List<SparePart> SpareParts { get; set; }

    }
}
