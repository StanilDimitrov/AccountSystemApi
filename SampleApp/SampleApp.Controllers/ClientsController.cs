using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Dal.Contracts;
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
        public async Task<ActionResult> CreateClientAsync(CreateClientCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to CreateUserAsync.");

            if (!ModelState.IsValid)
            {
                return BadRequest(command);
            }

            var result = await _mediator.Send(command);
           // var id = await _clientService.CreateCleintAsync(request, cancellationToken);

           return new ObjectResult(result.ClientId) { StatusCode = StatusCodes.Status201Created };
        }

        // PUT: api/Clients/5
        [HttpPut]
        public async Task<ActionResult> UpdateClientAsync(int id, ClientUpdateRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to UpdateUserAsync.");

            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            if (!request.Age.HasValue && !request.Gender.HasValue)
            {
                return BadRequest("Please enter at least one input parameter.");
            }

             await _clientService.UpdateClientAsync(id, request, cancellationToken);

            return Ok();
        }

        // DELETE: api/Clients/5
        [HttpDelete]
        public async Task<ActionResult> DeleteClientAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to UpdateUserAsync.");

            await _clientService.DeleteUserAsync(id, cancellationToken);

            return Ok();
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<QueryResult<ClientResponseModel>>> GetClientsGridAsync(string name, int? age, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to GetUsersGridAsync.");

           return await _clientService.GetClientGridAsync(name, age , cancellationToken);

        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponseModel>> GetClientDetailsAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to GetUserDetailsAsync.");

            var response = await _clientService.GetClientDetailsAsync(id, cancellationToken);
            return response;
        }
    }
}
