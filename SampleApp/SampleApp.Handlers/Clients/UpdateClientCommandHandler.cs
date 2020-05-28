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
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ClientDTO>
    {
        private readonly IClientService _clientService;
        private readonly ILogger _logger;

        public UpdateClientCommandHandler(
            IClientService clientService, 
            ILogger<UpdateClientCommandHandler> logger)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ClientDTO> Handle(
            UpdateClientCommand command,
            CancellationToken cancellationToken)
        {

           var clientDTO = await _clientService.UpdateClientAsync(command, cancellationToken);
           _logger.LogInformation($"Client with id: {clientDTO.ClientId} was updated.");

            return clientDTO;
        }
    }
}
