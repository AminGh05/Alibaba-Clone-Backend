using AlibabaClone.Application.DTOs.TransactionDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository transactionRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<long>> CreateAsync(long accountId, TransactionDto dto)
        {
            Transaction transaction = new();
            _mapper.Map(dto, transaction);
            transaction.AccountId = accountId;

            await _transactionRepository.InsertAsync(transaction);
            await _unitOfWork.CompleteAsync();
            return Result<long>.Success(transaction.Id);
        }

        public async Task<Result<long>> CreateTopUpAsync(long accountId, decimal amount)
        {
            Transaction transaction = new Transaction()
            {
                AccountId = accountId,
                CreatedAt = DateTime.UtcNow,
                Description = "Top-up at " + DateTime.UtcNow,
                BaseAmount = amount,
                FinalAmount = amount,
                SerialNumber = Guid.NewGuid().ToString("N"),
                TransactionTypeId = 1,
                TicketOrderId = null
            };

            await _transactionRepository.InsertAsync(transaction);
            await _unitOfWork.CompleteAsync();
            return Result<long>.Success(transaction.Id);
        }
    }
}
