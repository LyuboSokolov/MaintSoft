using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Models.SparePart
{
    public class SparePartAllViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Code { get; set; } = null!;

        public int Quantity { get; set; } = 0;

        public string? Description { get; set; }

        public string? Location { get; set; }

        public string ImageUrl { get; set; } = null!;

    }
}
