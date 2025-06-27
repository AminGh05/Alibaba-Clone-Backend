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

        public async Task<Result<ProfileDto>> GetProfileAsync(long accountId)
        {
            var result = await _accountRepository.GetProfileAsync(accountId);
            if (result == null)
            {
                return Result<ProfileDto>.NotFound(null);
            }

            return Result<ProfileDto>.Success(_mapper.Map<ProfileDto>(result));
        }
    }
}
