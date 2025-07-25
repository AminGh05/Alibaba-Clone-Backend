﻿using AlibabaClone.Domain.Aggregates.TransactionAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories
{
	public interface ITicketRepository : IRepository<Ticket, long>
	{
		Task<List<Ticket>> GetTicketsByTicketOrderId(long ticketOrderId);
	}
}
