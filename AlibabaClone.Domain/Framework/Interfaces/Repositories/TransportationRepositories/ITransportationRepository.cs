using AlibabaClone.Domain.Aggregates.TransportationAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories
{
	public interface ITransportationRepository : IRepository<Transportation, long>
	{
		public Task<IEnumerable<Transportation>> SearchTransportationsAsync(short vehicleTypeId, int? fromCityId, int? toCityId,
		DateTime? startDateTime, DateTime? endDateTime, short remainingCapacity);
	}
}
