using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Models.Machine
{
    public class MachineDetailsViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        [StringLength(100, MinimumLength = 3)]

        public string? Location { get; set; }

        public List<MachineAppTask> MachineAppTasks { get; set; }

        public List<MaintSoft.Infrastructure.Data.SparePart> SpareParts { get; set; }

        public string UserCreatedId { get; set; } = null!;

        [MaxLength(256)]
        public string? UserDeletedId { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
