using MediatR;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Dal.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Handlers.Accounts
{
    public class AddFundsToClientCommandHandler : IRequestHandler<AddFundsToClientCommand, int>
    {
        private readonly IAccountService _accountService;
        private readonly ILogger _logger;
        public AddFundsToClientCommandHandler(IAccountService accountService, ILogger<AddFundsToClientCommandHandler> logger)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddFundsToClientCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var accountDTO = await _accountService.AddFundsToClientAsync(command, cancellationToken);
            _logger.LogInformation($"To Client with id: {accountDTO.ClientId} was added new account with id: {accountDTO.AccountId} with sum: {accountDTO.Sum}");

            return accountDTO.AccountId;
        }
    }
}
