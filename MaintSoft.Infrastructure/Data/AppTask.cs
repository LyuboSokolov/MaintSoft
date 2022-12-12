using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [ForeignKey(nameof(StatusId))]
        public int StatusId { get; set; }

        public Status? Status { get; set; }

        [Required]
        [MaxLength(256)]
        public string UserCreatedId { get; set; } = null!;

        [MaxLength(256)]
        public string? UserContractorId { get; set; }


        [MaxLength(256)]
        public string? UserDeleteId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<MachineAppTask> MachinesAppTasks { get; set; }

        public List<ApplicationUserAppTask> ApplicationUsersAppTasks { get; set; }
    }
}
