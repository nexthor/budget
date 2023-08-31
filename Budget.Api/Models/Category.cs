namespace Budget.Api.Models
{
    public class Category : BaseTimeStamps
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
