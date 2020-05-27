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
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, AccountDTO>
    {
        private readonly IAccountService _accountService;
        private readonly ILogger _logger;

        public UpdateAccountCommandHandler(IAccountService accountService, ILogger<UpdateAccountCommandHandler> logger)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccountDTO> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
        {
            var accountDTO = await _accountService.UpdateAccountAsync(command, cancellationToken);
            _logger.LogInformation($"Account with id: {accountDTO.AccountId} was updated.");

            return accountDTO;
        }
    }
}
