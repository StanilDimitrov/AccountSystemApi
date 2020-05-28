using MediatR;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Handlers.Clients
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, ClientDTO>
    {
        private readonly IClientService _clientService;
        private readonly ILogger _logger;
        public DeleteClientCommandHandler(
            IClientService clientService,
            ILogger<DeleteClientCommandHandler> logger)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ClientDTO> Handle(
            DeleteClientCommand command,
            CancellationToken cancellationToken)
        {
            var clientDTO = await _clientService.DeleteClientAsync(command.ClientId, cancellationToken);
            _logger.LogInformation($"Client with id: {clientDTO.ClientId} was deleted.");

            return clientDTO;
        }
    }
}
