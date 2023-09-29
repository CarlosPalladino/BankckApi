using AutoMapper;
using BankckApi.Dtos;
using BankckApi.Models;

namespace BankckApi.Maps
{
    public class MapHelper : Profile
    {
        public MapHelper()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyDto, Currency>();

            CreateMap<ExchangeRate, ExchangeRateDto>();
            CreateMap<ExchangeRateDto, ExchangeRate>();





        }





    }
}
