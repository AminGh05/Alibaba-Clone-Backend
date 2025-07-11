using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.DTOs.CityDTOs;
using AlibabaClone.Application.DTOs.TransactionDTOs;
using AlibabaClone.Application.DTOs.TransportationDTOs;
using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Enums;
using AutoMapper;

namespace AlibabaClone.Application.Common.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transportation, TransportationSearchResultDto>()
                .ForMember(dest => dest.CompanyTitle, opt => opt.MapFrom(src => src.Company.Title))
                .ForMember(dest => dest.FromLocationTitle, opt => opt.MapFrom(src => src.FromLocation.Title))
                .ForMember(dest => dest.ToLocationTitle, opt => opt.MapFrom(src => src.ToLocation.Title))
                .ForMember(dest => dest.FromCityTitle, opt => opt.MapFrom(src => src.FromLocation.City.Title))
                .ForMember(dest => dest.ToCityTitle, opt => opt.MapFrom(src => src.ToLocation.City.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.BasePrice));

            CreateMap<City, CityDto>();

            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.AccountRoles.Select(x => x.Role.Title)));

            CreateMap<AccountDto, Account>()
                .ForMember(dest => dest.AccountRoles, opt => opt.Ignore());

            CreateMap<Account, ProfileDto>()
                .ForMember(dest => dest.AccountPhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person != null ? src.Person.FirstName : ""))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person != null ? src.Person.LastName : ""))
                .ForMember(dest => dest.IdNumber, opt => opt.MapFrom(src => src.Person != null ? src.Person.IdNumber : ""))
                .ForMember(dest => dest.PersonPhoneNumber, opt => opt.MapFrom(src => src.Person != null ? src.Person.PhoneNumber : ""))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Person != null ? src.Person.BirthDate : (DateTime?)null))
                .ForMember(dest => dest.IBAN, opt => opt.MapFrom(src => src.BankAccount != null ? src.BankAccount.IBAN : ""))
                .ForMember(dest => dest.BankAccountNumber, opt => opt.MapFrom(src => src.BankAccount != null ? src.BankAccount.BankAccountNumber : ""))
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.BankAccount != null ? src.BankAccount.CardNumber : ""));

            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.CreatorId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.IdNumber, opt => opt.MapFrom(src => src.IdNumber))
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ReverseMap();

            CreateMap<TicketOrder, TicketOrderSummaryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.BoughtAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Transaction != null ? src.Transaction.FinalAmount : 0))
                .ForMember(dest => dest.TravelStartDate, opt => opt.MapFrom(src => src.Transportation.StartDateTime))
                .ForMember(dest => dest.TravelEndDate, opt => opt.MapFrom(src => src.Transportation.EndDateTime))
                .ForMember(dest => dest.FromCity, opt => opt.MapFrom(src => src.Transportation.FromLocation.City.Title))
                .ForMember(dest => dest.ToCity, opt => opt.MapFrom(src => src.Transportation.ToLocation.City.Title))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Transportation.Company.Title))
                .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.Transportation.Vehicle.VehicleTypeId))
                .ForMember(dest => dest.VehicleName, opt => opt.MapFrom(src => src.Transportation.Vehicle.Title));

            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.Title))
                .ForMember(dest => dest.BaseAmount, opt => opt.MapFrom(src => src.BaseAmount))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.FinalAmount))
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<TransactionDto, Transaction>()
                .ForMember(dest => dest.TransactionType, opt => opt.Ignore())
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.TransactionType == "Deposit" ? 1 : 2));

            CreateMap<CreateTravellerTicketDto, PersonDto>();

            CreateMap<Seat, TransportationSeatDto>()
                .ForMember(dest => dest.IsReserved, opt => opt.MapFrom(src => src.Tickets.Any(t => t.TicketStatusId == (int)TicketStatusEnum.Reserved)))
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.Tickets.Any(t => t.TicketStatusId == (int)TicketStatusEnum.Reserved) ?
                src.Tickets.First(t => t.TicketStatusId == (int)TicketStatusEnum.Reserved).Traveler.GenderId : (short?)null));

            CreateMap<Ticket, TravellerTicketDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TravellerName, opt => opt.MapFrom(src => src.Traveler != null ? $"{src.Traveler.FirstName} {src.Traveler.LastName}" : ""))
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.TicketStatus, opt => opt.MapFrom(src => src.TicketStatus.Ttile))
                .ForMember(dest => dest.CompanionName, opt => opt.MapFrom(src => src.Companion != null ? $"{src.Companion.FirstName} {src.Companion.LastName}" : ""))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
