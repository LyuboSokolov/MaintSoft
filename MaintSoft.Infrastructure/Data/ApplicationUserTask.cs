using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class ApplicationUserTask
    {
        [Key]
        [ForeignKey(nameof(ApplicationUser))]
        public int ApplicationUserId { get;set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
