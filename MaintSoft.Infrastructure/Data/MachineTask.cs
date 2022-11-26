using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class MachineTask
    {
        [Key]
        [ForeignKey(nameof(Machine))]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }


        [Key]
        [ForeignKey(nameof(Machine))]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
