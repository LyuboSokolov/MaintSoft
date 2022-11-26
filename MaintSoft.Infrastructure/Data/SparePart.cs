using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class SparePart
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(100, MinimumLength = 3)]
        public string Code { get; set; } = null!;

        [Required]
        [Range(0, 100000)]
        public int Quantity { get; set; } = 0;


        [StringLength(1000, MinimumLength = 5)]
        public string Description { get; set; } = null!;


        [StringLength(20, MinimumLength = 5)]
        public string Location { get; set; } = null!;

        [Required]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;
    }
}
