namespace AlibabaClone.Application.DTOs.TransportationDTOs
{
	public record TransportationSearchRequestDto(
		int? FromCityId, 
		int? ToCityId, 
		DateTime? StartDate, 
		DateTime? EndDate);
}
