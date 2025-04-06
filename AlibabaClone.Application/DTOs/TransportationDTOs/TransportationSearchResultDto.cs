namespace AlibabaClone.Application.DTOs.TransportationDTOs
{
	public record TransportationSearchResultDto(
		long Id, 
		string CompanyTitle, 
		string FromLocationTitle,
		string ToLocationTitle,
		string FromCityTitle,
		string ToCityTitle,
		DateTime StartDateTime,
		DateTime? EndDateTime,
		decimal Price);
}
