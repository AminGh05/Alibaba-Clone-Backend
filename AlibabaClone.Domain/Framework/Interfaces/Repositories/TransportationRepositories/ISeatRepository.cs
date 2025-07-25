﻿using AlibabaClone.Domain.Aggregates.TransportationAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories
{
	public interface ISeatRepository : IRepository<Seat, long>
	{
		Task<List<Seat>> GetSeatsByVehicleIdAsync(long vehicleId);
    }
}
