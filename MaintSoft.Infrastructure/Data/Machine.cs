﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class Machine
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Code { get; set; } = null!;


        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; } = null!;


        [StringLength(100, MinimumLength = 3)]
        public string Location { get; set; } = null!;

        public List<MachineTask> MachineTasks { get; set; }
    }
}
