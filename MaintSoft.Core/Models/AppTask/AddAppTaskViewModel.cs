using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Models.AppTask
{
    public class AddAppTaskViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Name { get; set; } = null!;


        [MaxLength(1000)]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Required]
        public int StatusId { get; set; }
        public IEnumerable<Status> Status { get; set; } = Enumerable.Empty<Status>();

        [Required]
        public int MachineId { get; set; }
        public List<Machine> Machines { get; set; } = new List<Machine>();


      
   
    }
}
