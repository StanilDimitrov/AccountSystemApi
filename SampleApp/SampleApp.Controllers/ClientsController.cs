using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.Mappers;
using SampleApp.Core.Models.Query;
using SampleApp.Core.Models.Request;
using SampleApp.Core.Models.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IClientService _clientService;
        private readonly IMediator _mediator;

        public ClientsController(
            ILogger<ClientsController> logger,
            IClientService userService,
            IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _clientService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult> CreateClientAsync(CreateClientRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to CreateClientAsync.");

            var command = request.ToCreateClientCommand();
            var clientId = await _mediator.Send(command, cancellationToken);

            var response = new CreateClientResponseModel { ClientId = clientId };
            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClientAsync(int id, UpdateClientRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to UpdateClientAsync.");

            if (!request.Age.HasValue && !request.Gender.HasValue)
            {
                return BadRequest("Please enter at least one valid parameter.");
            }

            var command = request.ToUpdateClientCommand(id);
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClientAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to DeleteClientAsync.");

            var command = new DeleteClientCommand { ClientId = id };
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<QueryResult<ClientResponseModel>>> GetClientsGridAsync(string name, int? age, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to GetClientsGridAsync.");

           return await _clientService.GetClientsGridAsync(name, age, cancellationToken);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponseModel>> GetClientDetailsAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to GetClientDetailsAsync.");

            return await _clientService.GetClientDetailsAsync(id, cancellationToken);
        }
    }
}
