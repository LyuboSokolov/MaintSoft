using System.ComponentModel.DataAnnotations;

namespace MaintSoft.Infrastructure.Data
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; } = null!;
    }
}
