﻿using MediatR;
using BankckApi.Cqrs.Queries;
using BankckApi.Dtos;
using BankckApi.Models;
using BankckApi.Interfaces;
using AutoMapper;

namespace BankckApi.Cqrs.Handlers.Account
{
    public class AccountQueryHandler
        : IRequestHandler<GetAllAccounts, IEnumerable<AccountDto>>,
          IRequestHandler<GetAccountById, AccountDto>
        //IRequestHandler<GetAccountBycyustomer, CustomerDto>
    {
        private readonly AccoutInterface _interface;
        private readonly IMapper _mapper;

        public AccountQueryHandler(AccoutInterface @interface, IMapper mapper)
        {
            _interface = @interface;
            _mapper = mapper;
        }


        public async Task<IEnumerable<AccountDto>> Handle(GetAllAccounts request, CancellationToken cancellationToken)
        {
            var account = await _interface.GetAccounts();
            return _mapper.Map<IEnumerable<AccountDto>>(account);
        }

        public async Task<AccountDto> Handle(GetAccountById request, CancellationToken cancellationToken)
        {
            var AccountById = await _interface.GetAccount(request.Id);
                return _mapper.Map<AccountDto>(AccountById);
        }

   
    }
}
