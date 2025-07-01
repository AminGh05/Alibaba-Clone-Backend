using AlibabaClone.Application.Common.Utils;
using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.DTOs.TransactionDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository,
            IBankAccountRepository bankAccountRepository,
            IPersonRepository personRepository,
            ITicketOrderRepository ticketOrderRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _bankAccountRepository = bankAccountRepository;
            _personRepository = personRepository;
            _ticketOrderRepository = ticketOrderRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

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

        // a method to check validity of password
        // used just above
        private static bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasDigit = password.Any(char.IsDigit);
            bool hasLetter = password.Any(char.IsLetter);
            return hasDigit && hasLetter;
        }

        public async Task<Result<long>> UpsertBankAccountAsync(long accountId, UpsertBankAccountDto dto)
        {
            var error = ValidateBankInfo(dto);
            if (!string.IsNullOrEmpty(error))
            {
                return Result<long>.Error(0, error);
            }

            var bankAccount = await _bankAccountRepository.GetByAccountIdAsync(accountId);
            // if no account exists, then add one with the info given
            if (bankAccount == null)
            {
                bankAccount = new BankAccount()
                {
                    AccountId = accountId,
                    BankAccountNumber = dto.BankAccountNumber,
                    CardNumber = dto.CardNumber,
                    IBAN = dto.IBAN
                };
                await _bankAccountRepository.InsertAsync(bankAccount);
            }
            else
            {
                bankAccount.BankAccountNumber = dto.BankAccountNumber;
                bankAccount.CardNumber = dto.CardNumber;
                bankAccount.IBAN = dto.IBAN;
                
                _bankAccountRepository.Update(bankAccount);
            }

            await _unitOfWork.CompleteAsync();
            return Result<long>.Success(accountId);
        }

        private static string ValidateBankInfo(UpsertBankAccountDto dto)
        {
            if (!string.IsNullOrEmpty(dto.IBAN) && dto.IBAN.Length != 24 && dto.IBAN.Any(x => char.IsDigit(x) == false))
                return "IBAN must be 24 digits";

            if (!string.IsNullOrEmpty(dto.CardNumber))
            {
                var digitsOnly = dto.CardNumber.Replace("-", "");
                if (digitsOnly.Length != 16 || !digitsOnly.All(char.IsDigit))
                    return "Invalid card-number format";
            }
            return "";
        }

        public async Task<Result<List<PersonDto>>> GetAllPeopleAsync(long accountId)
        {
            var result = await _personRepository.GetAllByCreatorIdAsync(accountId);
            if (result == null)
            {
                return Result<List<PersonDto>>.NotFound(null);
            }

            return Result<List<PersonDto>>.Success(_mapper.Map<List<PersonDto>>(result));
        }

        public async Task<Result<List<TicketOrderSummaryDto>>> GetTravelsAsync(long accountId)
        {
            var result = await _ticketOrderRepository.GetAllByBuyerId(accountId);
            if (result == null)
            {
                return Result<List<TicketOrderSummaryDto>>.NotFound(null);
            }

            return Result<List<TicketOrderSummaryDto>>.Success(_mapper.Map<List<TicketOrderSummaryDto>>(result));
        }
    }
}
