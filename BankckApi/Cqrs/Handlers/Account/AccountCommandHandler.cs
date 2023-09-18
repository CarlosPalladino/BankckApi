using MediatR;
using BankckApi.Interfaces;
using BankckApi.Models;
using BankckApi.Cqrs.Commands;
using Azure.Core;
using System.Runtime.CompilerServices;
using BankckApi.Dtos;

namespace BankckApi.Cqrs.Handlers.Account
{
    public class AccountHandler
        : IRequestHandler<CreateAccountCommand, bool>,
          IRequestHandler<UpdateAccountCommand, bool>,
          IRequestHandler<DeleteAccountCommand, bool>

    {

        private readonly AccoutInterface _interface;

        public AccountHandler(AccoutInterface @interface)
        {
            _interface = @interface;
        }



        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {

            return await _interface.DeleteAccout(request.Account);


        }



        public async Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {

            return await _interface.UpdateAccout(request.Account);
        }

        public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {

            return await _interface.CreateAccout(request.Account);
        }
    }


}

//public async Task<bool> Handle(AccountCommand request, CancellationToken cancellationToken)
//{
//    var account = new Account

//    {
//        AccountNumber = request.AccountNumber,
//        Balance = request.InitialBalance,
//        CustomerId = request.CustomerId,
//        CreatedAt = DateTime.Now, // Asignar la fecha actual
//        IsLocked = false // Por defecto, la cuenta no está bloqueada
//    };

//    return await _interface.CreateAccout(account);
//}



//public async Task<Account> Handle(ReadAccount request, CancellationToken cancellationToken)
//{
//    try
//    {

//        var accountId = request.AccountId;
//        return await _interface.GetAccount(accountId);

//    }
//    catch (Exception ex)
//    {

//        Console.WriteLine($"Error al cargar la cuenta de {ex.Message}");
//        return null;
//    }
//}
//public async Task<List<Account>> Handle(GetAccountByCustomerCommand req, CancellationToken cancellationToken)
//{
//    var customerId = req.CustomerId;
//    var accounts = await _interface.GetAccounts();
//    var filteredAccounts = accounts.Where(a => a.CustomerId == customerId).ToList();

//    return filteredAccounts;
//}















