using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Models.Asset
{
    public class AssetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }


        public bool IsDelete { get; set; } = false;

        public string UserCreatedId { get; set; } = null!;

        public string? PersonResponsible { get; set; }

        public string? UserDeletedId { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
