namespace AlibabaClone.Application.DTOs.TransportationDTOs
{
    public class CreateTicketOrderDto
    {
        public long TransportationId { get; set; }
        public List<CreateTravellerTicketDto> Travellers { get; set; }
    }
}
