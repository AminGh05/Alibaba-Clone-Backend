using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransportationRepositories
{
	internal class CompanyRepository : BaseRepository<AlibabaDbContext, Company, int>, ICompanyRepository
	{
		public CompanyRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
