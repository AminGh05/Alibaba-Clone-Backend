using AlibabaClone.Application.Common.Utils;
using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.DTOs.AuthDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, 
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _accountRoleRepository = accountRoleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        private static bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                return false;
            }
            
            return password.Any(char.IsDigit) && password.Any(char.IsLetter); 
        }

        public async Task<Result<AuthResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var account = await _accountRepository.GetByPhoneNumberAsync(request.PhoneNumber);
            var accountDto = _mapper.Map<AccountDto>(account);
            // check phone and password to find account
            if (accountDto == null || !PasswordHasher.VerifyPassword(request.Password, accountDto.Password))
            {
                return Result<AuthResponseDto>.Error("Invalid phone number or password");
            }

            var response = new AuthResponseDto
            {
                Id = accountDto.Id,
                PhoneNumber = accountDto.PhoneNumber,
                Roles = accountDto.Roles
            };
            return Result<AuthResponseDto>.Success(response);
        }

        public async Task<Result<AuthResponseDto>> RegisterAsync(RegisterRequestDto request)
        {
            // check if same number is already in database
            var existing = await _accountRepository.GetByPhoneNumberAsync(request.PhoneNumber);
            if (existing != null)
            {
                return Result<AuthResponseDto>.Error("Phone Number already exists");
            }

            if (!IsPasswordStrong(request.Password))
            {
                return Result<AuthResponseDto>.Error("Password should contain at least 8 chars including letters and numbers");
            }

            // create an account-dto and add it to database
            var accountDto = new AccountDto()
            {
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Password = PasswordHasher.HashPassword(request.Password),
                Roles = ["User"]
            };
            await _accountRepository.InsertAsync(_mapper.Map<Account>(accountDto));
            await _unitOfWork.CompleteAsync();

            // add account role by account
            var account = await _accountRepository.GetByPhoneNumberAsync(request.PhoneNumber);
            var accountRole = new AccountRole
            {
                AccountId = account.Id,
                RoleId = 1
            };
            await _accountRoleRepository.InsertAsync(accountRole);
            await _unitOfWork.CompleteAsync();

            // create the response and return it
            var response = new AuthResponseDto
            {
                Id = account.Id,
                PhoneNumber = request.PhoneNumber,
                Roles = ["User"]
            };
            return Result<AuthResponseDto>.Success(response);
        }
    }
}
