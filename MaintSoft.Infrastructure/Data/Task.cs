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


        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        public List<MachineTask> MachineTasks { get; set; }

        public List<ApplicationUserTask> ApplicationUserTasks { get; set; }
    }
}
