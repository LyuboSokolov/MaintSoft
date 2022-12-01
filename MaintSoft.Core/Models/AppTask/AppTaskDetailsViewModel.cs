using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Models.AppTask
{
    public class AppTaskDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Status { get; set; }


        public string UserCreatedFullName { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        public string? UserContractorFullName { get; set; }

        //public List<MachineAppTask> MachineAppTasks { get; set; }

        //public List<ApplicationUserAppTask> ApplicationUserAppTasks { get; set; }
        public List<MaintSoft.Infrastructure.Data.SparePart> SpareParts { get; set; } 

        public string MachineName { get; set; }

        public int MachineId { get; set; }


    }
}

