using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<Result<ProfileDto>> GetProfileAsync(long accountId)
        {
            var result = await _accountRepository.GetProfileAsync(accountId);
            if (result == null)
            {
                return Result<ProfileDto>.NotFound(null);
            }

            return Result<ProfileDto>.Success(_mapper.Map<ProfileDto>(result));
        }

        public async Task<Result<long>> UpdateEmailAsync(long accountId, string email)
        {
            // find account by its id
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account  == null)
            {
                throw new Exception("Account not found");
            }
            // find account by its email to compare with the new email
            var existingAccount = await _accountRepository.GetByEmailAsync(email);
            if (existingAccount != null)
            {
                if (existingAccount.Id != accountId)
                {
                    return Result<long>.Error(account.Id, "This email is already in use");
                }
                else
                {
                    return Result<long>.Success(accountId);
                }
            }

            // update the email
            account.Email = email;
            _accountRepository.Update(account);
            await _unitOfWork.CompleteAsync();
            return Result<long>.Success(account.Id);
        }
    }
}
