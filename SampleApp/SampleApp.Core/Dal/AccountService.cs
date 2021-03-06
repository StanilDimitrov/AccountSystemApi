﻿using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.CustomExceptions;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Data;
using SampleApp.Core.Entities;
using SampleApp.Core.Enums;
using SampleApp.Core.Models.DTOs;
using SampleApp.Core.Models.Mappers;
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
        public async Task<AccountDTO> AddFundsToClientAsync(AddFundsToClientCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = await _clientService.GetClientAsync(command.ClientId, cancellationToken);

            var account = new Account
            {
                Sum = command.Sum,
                Type = command.Type,
                ClientId = client.ClientId
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync(cancellationToken);
            return account.ToDTO();
        }

        public async Task<AccountDTO> UpdateAccountAsync(UpdateAccountCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var account = await GetAccountAsync(command.AccountId, cancellationToken);

            SetAccountProperties(account, command);
            await _context.SaveChangesAsync(cancellationToken);
            return account.ToDTO();
        }

        private async Task<Account> GetAccountAsync(int accountId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var account = await _context.Accounts.SingleOrDefaultAsync(x => x.AccountId == accountId, cancellationToken);

            if (account == null)
            {
                throw new NotFoundException($"Account with id: {accountId} does not exist.");
            }

            return account;
        }

        private void SetAccountProperties(Account account, UpdateAccountCommand command)
        {
            if (command.Sum.HasValue)
            {
                if (account.Type == AccountType.Deposit)
                {
                    account.Sum += command.Sum.Value;

                    if (account.Sum < 0)
                    {
                        throw new AccountInvalidOperationException("Deposit sum can not be less than 0.");
                    }
                }
                else
                {
                    account.Sum += command.Sum.Value;
                }
            }

            if (command.Type.HasValue)
            {
                account.Type = command.Type.Value;
            }
        }
    }
}
