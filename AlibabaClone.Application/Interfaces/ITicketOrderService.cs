using AlibabaClone.Application.DTOs.TransportationDTOs;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface ITicketOrderService
    {
        Task<Result<long>> CreateTicketOrderAsync(long accountId, CreateTicketOrderDto dto);
    }
}
