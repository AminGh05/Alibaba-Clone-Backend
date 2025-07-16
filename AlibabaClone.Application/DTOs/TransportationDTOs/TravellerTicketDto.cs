namespace AlibabaClone.Application.DTOs.TransportationDTOs
{
    public class TravellerTicketDto
    {
        public long Id { get; set; }
        public required string SerialNumber { get; set; }
        public required string TravellerName { get; set; }
        public DateTime BirthDate { get; set; }
        public required string SeatNumber { get; set; }
        public required string TicketStatus { get; set; }
        public string? CompanionName { get; set; }
        public string? Description { get; set; }
    }
}
