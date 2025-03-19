using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure
{
	public class AlibabaDbContext : DbContext
	{
		public AlibabaDbContext(DbContextOptions<AlibabaDbContext> options) : base(options)
		{

		}

		#region Account Aggregates
		public DbSet<Account> Accounts { get; set; }
		public DbSet<AccountRole> AccountRoles { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Person> People { get; set; }
		public DbSet<Role> Roles { get; set; }
		#endregion

		#region Location Aggregates
		public DbSet<City> Cities { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<LocationType> LocationTypes { get; set; }
		#endregion

		#region Transaction Aggregates
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<TicketStatus> TicketStatuses { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		#endregion

		#region Transportation Aggregates
		public DbSet<Company> Companies { get; set; }
		public DbSet<Seat> Seats { get; set; }
		public DbSet<Transportation> Transportations { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<VehicleType> VehicleTypes { get; set; }
		#endregion

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlibabaDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
