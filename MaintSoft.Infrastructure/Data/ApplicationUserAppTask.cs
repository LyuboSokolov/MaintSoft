using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Infrastructure.Data
{
    public class ApplicationUserAppTask
    {
        [Key]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get;set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }
        public AppTask Task { get; set; }
    }
}
