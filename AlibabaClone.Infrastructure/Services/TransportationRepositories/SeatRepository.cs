using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransportationRepositories
{
    public class SeatRepository : BaseRepository<AlibabaDbContext, Seat, long>, ISeatRepository
	{
		public SeatRepository(AlibabaDbContext context) : base(context)
		{

		}

        public Task<List<Seat>> GetSeatsByVehicleIdAsync(long vehicleId)
        {
            var seats = DbSet
                .Include(s => s.Vehicle)
                .Include(s => s.Tickets).ThenInclude(t => t.Traveler)
                .Where(s => s.VehicleId == vehicleId).ToListAsync();
            return seats;
        }
    }
}
