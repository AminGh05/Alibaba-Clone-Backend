using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransportationRepositories
{
	public class TransportationRepository : BaseRepository<AlibabaDbContext, Transportation, long>, ITransportationRepository
	{
		public TransportationRepository(AlibabaDbContext context) : base(context)
		{

		}

		public async Task<IEnumerable<Transportation>> SearchTransportationsAsync(short vehicleTypeId, int? fromCityId, int? toCityId, DateTime? startDateTime, DateTime? endDateTime)
		{
			var query = DbSet
				.Include(t => t.Vehicle)
				.Include(t => t.FromLocation).ThenInclude(fl => fl.City)
				.Include(t => t.ToLocation).ThenInclude(tl => tl.City)
				.Include(t => t.Company)
				.AsQueryable();

			query = query.Where(t => t.Vehicle.VehicleTypeId == vehicleTypeId);
			query = query.Where(t => fromCityId == null || t.FromLocation.CityId == fromCityId.Value);
			query = query.Where(t => toCityId == null || t.ToLocation.CityId == toCityId.Value);
			query = query.Where(t => startDateTime == null || t.StartDateTime.Date == startDateTime.Value.Date);
			query = query.Where(t => endDateTime == null || t.EndDateTime.Date == endDateTime.Value.Date);

			return await query.ToListAsync();
		}
	}
}
