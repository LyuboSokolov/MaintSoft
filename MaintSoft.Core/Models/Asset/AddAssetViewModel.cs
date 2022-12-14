using MaintSoft.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace MaintSoft.Core.Models.Asset
{
    public class AddAssetViewModel
    {


        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; } = Enumerable.Empty<ApplicationUser>();

        public bool IsAvailable { get; set; } = true;

        
        public string? UserCreatedId { get; set; } 

        [MaxLength(256)]
        public string? UserDeletedId { get; set; }
    }
}
