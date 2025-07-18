﻿using AlibabaClone.Domain.Aggregates.AccountAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories
{
	public interface IPersonRepository : IRepository<Person, long>
	{
		Task<List<Person>> GetAllByCreatorIdAsync(long creatorId);
	}
}
