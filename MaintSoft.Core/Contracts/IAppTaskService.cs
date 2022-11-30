using MaintSoft.Core.Models.AppTask;
using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Contracts
{
    public interface IAppTaskService
    {
        Task<IEnumerable<AppTaskViewModel>> GetAllAppTaskAsync();

        Task<int> Create(AddAppTaskViewModel model,string userId);

        Task<IEnumerable<Status>> GetAllStatusAsync();
    }
}
