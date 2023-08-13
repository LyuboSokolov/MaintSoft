namespace MaintSoft.Areas.Admin.Models
{
    public class UserServiceModel
    {
        public string UserId { get; init; } = null!;
        public string Email { get; init; } = null!;

        public string FullName { get; init; } = null!;

        public string? JobPosition { get; init; } = null;

        public bool IsDelete { get; set; } = false;

        public IEnumerable<string> Role { get; init; } = null!;
    }
}
