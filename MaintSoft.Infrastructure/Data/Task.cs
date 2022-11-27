using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class Task
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Name { get; set; } = null!;


        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public bool IsDelete { get; set; } = false;

        public List<MachineTask> MachineTasks { get; set; }

        public List<ApplicationUserTask> ApplicationUserTasks { get; set; }
    }
}
