using MediatR;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Data;
using SampleApp.Core.Entities;
using SampleApp.Core.Models.DTOs;
using SampleApp.Core.Models.Mappers;
using SampleApp.Core.Models.Request;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Handlers
{
    public class CreateClientCommandHandler: IRequestHandler<CreateClientCommand, ClientDTO>
    {
        private readonly AccountContext _context;
        private readonly ILogger _logger;
        public CreateClientCommandHandler(AccountContext context, ILogger<CreateClientCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ClientDTO> Handle(
            CreateClientCommand request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = new Client
            {
                Name = request.Name,
                Age = request.Age,
                Gender = request.Gender
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Client with name: {client.Name}, age: {client.Age} was created.");

            return client.ToDTO();
        }
    }
}
