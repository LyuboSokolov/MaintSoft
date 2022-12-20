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
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(100, MinimumLength = 3)]
        public string? Code { get; set; } = null!;

        [Required]
        [Range(0, 100000)]
        public int Quantity { get; set; } = 0;


        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(20)]
        public string? Location { get; set; }

        [Required]
        [MaxLength(2048)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ManufacturerId))]
        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; } = null!;

        [Required]
        public bool IsDelete { get; set; } = false;

        [Required]
        [MaxLength(256)]
        public string UserCreatedId { get; set; } = null!;

        [MaxLength(256)]
        public string? UserDeletedId { get; set; }

        public List<Machine> Machines { get; set; } = new List<Machine>();

    }
}
