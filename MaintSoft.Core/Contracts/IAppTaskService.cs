using MaintSoft.Core.Models.AppTask;
using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Contracts
{
    public interface IAppTaskService
    {
        Task<List<AppTask>> GetAllAppTaskAsync(string? status = null, string? searchTerm = null);

        Task<int> CreateAsync(AddAppTaskViewModel model,string userId);

        Task<IEnumerable<Status>> GetAllStatusAsync();

        Task<AppTask> GetAppTaskByIdAsync(int appTaskId);

        Task<Status> GetStatusByIdAsync(int statusId);

        Task<bool> Exists(int id);

        Task StartStopTaskAsync(int appTaskId);

        Task CompleteTaskAsync (int appTaskId, string userId);

        Task DeleteAsync(int appTaskId, string userId);

        Task<IEnumerable<string>> AllStatusNames();


        //Task AddSparePart (int appTaskId,string machineName,int sparePartId);
    }
}
