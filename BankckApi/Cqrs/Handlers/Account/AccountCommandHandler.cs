using MediatR;
using BankckApi.Interfaces;
using BankckApi.Models;
using BankckApi.Cqrs.Commands.Account;
using Azure.Core;
using System.Runtime.CompilerServices;
using BankckApi.Dtos;

namespace BankckApi.Cqrs.Handlers.Account
{
    public class AccountHandler
        : IRequestHandler<CreateAccountCommand, AccountDto>,
          IRequestHandler<UpdateAccount, AccountDto>,
          IRequestHandler<DeleteAccountCommand, bool>

    {

        private readonly AccoutInterface _interface;

        public AccountHandler(AccoutInterface @interface)
        {
            _interface = @interface;
        }


        public async Task<AccountDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new AccountDto
            {
                Id = request.Id,
                AccountNumber = request.AccountNumber,
                Balance = request.balance,
                IsLocked = false

            };
            return await _interface.CreateAccout(account);
        }

        public Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDto> Handle(UpdateAccount request, CancellationToken cancellationToken)
        {
            var account = new Account
            {
                Id = request.Id,
                AccoutNummber = request.AccoutNumber,
                Balance = request.balance,
            };
            return await _interface.UpdateAccout(account);
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















