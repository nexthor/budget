using Microsoft.AspNetCore.Identity;

namespace Budget.Api.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
