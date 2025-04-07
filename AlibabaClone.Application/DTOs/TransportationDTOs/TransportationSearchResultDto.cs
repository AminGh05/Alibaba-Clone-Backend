namespace AlibabaClone.Application.DTOs.TransportationDTOs
{
	public class TransportationSearchResultDto
	{
		public required long Id { get; init; }
		public required string CompanyTitle { get; init; }
		public required string FromLocationTitle { get; init; }
		public required string ToLocationTitle { get; init; }
		public required string FromCityTitle { get; init; }
		public required string ToCityTitle { get; init; }
		public required DateTime StartDateTime { get; init; }
		public DateTime? EndDateTime { get; init; }
		public required decimal Price { get; init; }
	}
}
