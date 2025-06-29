using AlibabaClone.Application.Common.Utils;
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

        public async Task<Result<long>> UpdatePasswordAsync(long accountId, string oldPassword, string newPassword)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            // check old-password's correction
            if (!PasswordHasher.VerifyPassword(oldPassword, account.Password))
            {
                return Result<long>.Error(0, "Old password doesn't match");
            }
            // check validity of new password
            if (!IsPasswordStrong(newPassword))
            {
                return Result<long>.Error(0, "New password is not valid");
            }

            account.Password = PasswordHasher.HashPassword(newPassword);
            _accountRepository.Update(account);
            await _unitOfWork.CompleteAsync();
            return Result<long>.Success(account.Id);
        }

        private static bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasDigit = password.Any(char.IsDigit);
            bool hasLetter = password.Any(char.IsLetter);
            return hasDigit && hasLetter;
        }
    }
}
