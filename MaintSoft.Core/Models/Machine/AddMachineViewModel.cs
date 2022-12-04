using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Models.Machine
{
    public class AddMachineViewModel
    {

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Code { get; set; } = null!;


        [StringLength(100, MinimumLength = 5)]
        public string? Description { get; set; }


        [StringLength(100, MinimumLength = 3)]
        public string? Location { get; set; }

    }
}
