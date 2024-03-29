﻿using Microsoft.AspNetCore.Identity;
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

        public List<ApplicationUserAppTask> ApplicationUserAppTasks { get; set; }

        public List<Asset> Assets { get; set; }

    }
}
