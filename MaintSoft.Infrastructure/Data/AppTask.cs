using System.ComponentModel.DataAnnotations;

namespace MaintSoft.Infrastructure.Data
{
    public class AppTask
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Name { get; set; } = null!;


        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public bool IsDelete { get; set; } = false;

        public List<MachineAppTask> MachineAppTasks { get; set; }

        public List<ApplicationUserAppTask> ApplicationUserAppTasks { get; set; }
    }
}
