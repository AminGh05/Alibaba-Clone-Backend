﻿namespace AlibabaClone.Application.DTOs.TransportationDTOs
{
	public record TransportationSearchRequestDto
	{
		public short VehicleTypeId { get; init; }
		public int? FromCityId { get; init; }
		public int? ToCityId { get; init; }
		public DateTime? StartDate { get; init; }
		public DateTime? EndDate { get; init; }
        public short PassengerCount { get; set; }
    }
}
