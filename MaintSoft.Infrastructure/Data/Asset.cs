﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class Asset
    {
        [Key]
        
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; }


        [Required]
        public bool IsDelete { get; set; } = false;

        [Required]
        public bool IsAvailable { get; set; } = true;

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserCreatedId { get; set; } = null!;

        [MaxLength(450)]
        public string? UserDeletedId { get; set; }



    }
}
