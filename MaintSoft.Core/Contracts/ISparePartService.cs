using MaintSoft.Core.Models.SparePart;
using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Contracts
{

    public interface ISparePartService
    {
        Task<int> Create(SparePartViewModel model, string userId);
    }
}
