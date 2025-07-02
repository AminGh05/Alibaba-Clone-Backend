namespace AlibabaClone.Application.DTOs.TransactionDTOs
{
    public class TransactionDto
    {
        public long Id { get; set; }
        public short TransactionTypeId { get; set; }
        public long AccountId { get; set; }
        public long? TicketOrderId { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }
        public string TransactionType { get; set; }
    }
}
