using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Models.AppTask
{
    public class AppTasksQueryModel
    {
        public int TotalAppTasksCount { get; set; }

        public IEnumerable<AppTaskViewModel> AppTasks { get; set; }
    }
}
