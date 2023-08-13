using MaintSoft.Core.Models.AppTask;
using MaintSoft.Infrastructure.Data;

namespace MaintSoft.Models
{
    public class AllAppTaskQueryModel
    {
        public const int AppTasksPerPage = 4;

        public string? Status { get; set; }

        public string? SearchTerm { get; set; }

        public AppTaskSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalAppTasksCount { get; set; }

        public IEnumerable<string> AllStatusNames { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<AppTaskViewModel> AppTasks { get; set; } = Enumerable.Empty<AppTaskViewModel>();
    }
}
