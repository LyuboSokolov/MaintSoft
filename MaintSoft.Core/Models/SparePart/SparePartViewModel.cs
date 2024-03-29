﻿using System.ComponentModel.DataAnnotations;
using MaintSoft.Infrastructure.Data;
namespace MaintSoft.Core.Models.SparePart
{
    public class SparePartViewModel
    {

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
        public int ManufacturerId { get; set; }

        public IEnumerable<MaintSoft.Infrastructure.Data.Manufacturer>? Manufacturers { get; set; }
   
    }
}
