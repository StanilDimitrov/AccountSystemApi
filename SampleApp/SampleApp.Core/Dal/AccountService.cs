using Microsoft.EntityFrameworkCore;
using SampleApp.Core.CustomExceptions;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Data;
using SampleApp.Core.Entities;
using SampleApp.Core.Enums;
using SampleApp.Core.Models.Request;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal
{
    public class AccountService : IAccountService
    {
        private readonly AccountContext _context;
        private readonly IClientService _clientService;

        public AccountService(AccountContext context, IClientService clientService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }
        public async Task<int> AddFundsToClientAccountAsync(int clientId, AddFundsToAccountRequestModel requestModel, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = _clientService.GetClientAsync(clientId, cancellationToken);

            var account = new Account
            {
                Sum = requestModel.Sum,
                AccountType = requestModel.AccountType,
                ClientId = client.Id
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync(cancellationToken);

            return account.AccountId;
        }

        public async Task UpdateAccountAsync(int accountId, UpdateAccountRequestModel requestModel, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var account = await GetAccountAsync(accountId, cancellationToken);
            SetAccountProperties(account, requestModel);

           await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task<Account> GetAccountAsync(int accountId, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.SingleOrDefaultAsync(x => x.AccountId == accountId, cancellationToken);

            if (account == null)
            {
                throw new NotFoundException($"Account with id: {accountId} does not exist.");
            }

            return account;
        }

        private void SetAccountProperties(Account account, UpdateAccountRequestModel requestModel)
        {
            if (requestModel.Sum != null)
            {
                if (account.AccountType == AccountType.Deposit)
                {
                    account.Sum += (decimal)requestModel.Sum;

                    if (account.Sum < 0)
                    {
                        throw new AccountInvalidOperationException("Deposit sum can not be less than 0.");
                    }
                }
                else
                {
                    account.Sum += (decimal)requestModel.Sum;
                }
            }

            if (requestModel.AccountType != null)
            {
                account.AccountType = (AccountType)requestModel.AccountType;
            }
        }
    }
}
