using MediatR;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Contract;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Handlers
{
    public class AddFundsToAccountCommandHandler : IRequestHandler<AddFundsToAccountCommand, int>
    {
        private readonly IAccountService _accountService;
        private readonly ILogger _logger;
        public AddFundsToAccountCommandHandler(IAccountService accountService, ILogger<AddFundsToAccountCommandHandler> logger)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddFundsToAccountCommand command, CancellationToken cancellationToken)
        {
            var accountDTO = await _accountService.AddFundsToClientAccountAsync(command, cancellationToken);
            _logger.LogInformation($"To Client with id: {accountDTO.ClientId} was added new account with id: {accountDTO.AccountId} with sum: {accountDTO.Sum}");

            return accountDTO.AccountId;
        }
    }
}
