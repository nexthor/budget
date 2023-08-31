using Budget.Api.Common;

namespace Budget.Api.Models
{
    public class Transaction : BaseTimeStamps
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? UserId { get; set; }
        public string? CategoryId { get; set; }
        public TransactionType TransactionType { get; set; } = TransactionType.Income;
        public string? Description { get; set; }
        public double? Amount { get; set; }
        public bool IsRecurrent { get; set; }
        public RecurringFrecuency RecurringFrecuency { get; set; } = RecurringFrecuency.None;
        public DateTime? RecurringEndDate { get; set; }
        public TransactionStatus Status { get; set; } = TransactionStatus.Active;
        public User? User { get; set; }
        public Category? Category { get; set; }
    }
}
