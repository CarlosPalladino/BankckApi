using MediatR;
using BankckApi.Interfaces;
using BankckApi.Models;
using BankckApi.Cqrs.Commands;
using Azure.Core;
using System.Runtime.CompilerServices;
using BankckApi.Dtos;
using AutoMapper;

namespace BankckApi.Cqrs.Handlers.Account
{
    public class AccountHandler
        : IRequestHandler<CreateAccountCommand, bool>,
          IRequestHandler<UpdateAccountCommand, bool>,
          IRequestHandler<DeleteAccountCommand, bool>

    {

        private readonly AccoutInterface _interface;
        private readonly IMapper _mapper;


        public AccountHandler(AccoutInterface @interface, IMapper mapper)
        {
            _interface = @interface;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            return await _interface.DeleteAccout(request.Account);
        }

        public async Task<bool> Handle(UpdateAccountCommand  request, CancellationToken cancellationToken)
        {
            return await _interface.UpdateAccout(request.Account);
        }
        public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return await _interface.CreateAccout(request.Account);
        }
    }


}













