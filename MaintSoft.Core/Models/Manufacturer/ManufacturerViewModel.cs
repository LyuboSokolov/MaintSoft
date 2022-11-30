using System.ComponentModel.DataAnnotations;

namespace MaintSoft.Core.Models.Manufacturer
{
    public class ManufacturerViewModel
    {
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

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
