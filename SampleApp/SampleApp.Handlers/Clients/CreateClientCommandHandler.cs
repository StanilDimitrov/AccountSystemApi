using MediatR;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Dal.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Handlers.Clients
{
    public class CreateClientCommandHandler: IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientService _clientService;
        private readonly ILogger _logger;
        public CreateClientCommandHandler(IClientService clientService, ILogger<CreateClientCommandHandler> logger)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(
            CreateClientCommand command,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var clientDTO = await _clientService.CreateClientAsync(command, cancellationToken);
            _logger.LogInformation($"Client with name: {clientDTO.Name} and age: {clientDTO.Age}  was created.");

            return clientDTO.ClientId;
        }
    }
}
