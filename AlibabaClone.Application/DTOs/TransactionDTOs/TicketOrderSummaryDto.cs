namespace AlibabaClone.Application.DTOs.TransactionDTOs
{
    public class TicketOrderSummaryDto
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime BoughtAt { get; set; }

        // transaction
        public decimal Price { get; set; }

        // transportation
        public DateTime TravelStartDate { get; set; }
        public DateTime? TravelEndDate { get; set; }

        // city
        public string FromCity { get; set; }
        public string ToCity { get; set; }

        // company
        public string CompanyName { get; set; }

        // vehicle data
        public short VehicleTypeId { get; set; }
        public string VehicleName { get; set; }
    }
}
