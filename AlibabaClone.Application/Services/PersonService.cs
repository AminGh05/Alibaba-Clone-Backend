using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IPersonRepository personRepository,
            IAccountRepository accountRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<long>> UpsertAccountPersonAsync(long accountId, PersonDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            
            // if account is not null, update its person
            Person person;
            if (account.PersonId.HasValue)
            {
                person = await _personRepository.GetByIdAsync(account.PersonId.Value);
                if (person == null)
                {
                    return Result<long>.Error(0, "No person found for this account");
                }

                _mapper.Map(dto, person);
                person.CreatorId = account.Id;
                person.Id = account.PersonId.Value;
                _personRepository.Update(person);
            }
            else
            {
                person = _mapper.Map<Person>(dto);
                person.CreatorId = account.Id;
                await _personRepository.InsertAsync(person);
            }
            await _unitOfWork.CompleteAsync();

            account.PersonId = person.Id;
            _accountRepository.Update(account);
            await _unitOfWork.CompleteAsync();

            return Result<long>.Success(person.Id);
        }

        public async Task<Result<long>> UpsertPersonAsync(long accountId, PersonDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            Person person = (await _personRepository.FindAsync(p => p.IdNumber == dto.IdNumber && p.CreatorId == accountId)).FirstOrDefault();
            if (person != null)
            {
                if (dto.Id > 0 && dto.Id != person.Id)
                {
                    return Result<long>.Error(0, "A person with this id number exists");
                }
                _mapper.Map(dto, person);
                person.CreatorId = accountId;
                _personRepository.Update(person);
            }
            else
            {
                person = _mapper.Map<Person>(dto);
                person.CreatorId = accountId;
                await _personRepository.InsertAsync(person);
            }
            await _unitOfWork.CompleteAsync();

            return Result<long>.Success(person.Id);
        }
    }
}
