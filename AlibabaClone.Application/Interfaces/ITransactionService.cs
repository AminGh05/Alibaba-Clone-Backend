﻿using AlibabaClone.Application.DTOs.TransactionDTOs;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<Result<long>> CreateTopUpAsync(long accountId, decimal amount);
        Task<Result<long>> CreateAsync(long accountId, TransactionDto dto);
    }
}
