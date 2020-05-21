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
        private readonly IUserService _userService;

        public ClientsController(ILogger<ClientsController> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult> CreateClientAsync(ClientCreateRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to CreateUserAsync.");

            var id = await _userService.CreateCleintAsync(request, cancellationToken);

           return new ObjectResult(id) { StatusCode = StatusCodes.Status201Created };
        }

        // PUT: api/Users/5
        [HttpPut]
        public async Task<ActionResult> UpdateClientAsync(int id, ClientUpdateRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to UpdateUserAsync.");

             await _userService.UpdateClientAsync(id,request, cancellationToken);

            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete]
        public async Task<ActionResult> DeleteClientAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to UpdateUserAsync.");

            await _userService.DeleteUserAsync(id, cancellationToken);

            return Ok();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<QueryResult<ClientResponseModel>>> GetClientsGridAsync(string name, int? age, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to GetUsersGridAsync.");

           return await _userService.GetClientGridAsync(name, age , cancellationToken);

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponseModel>> GetClientDetailsAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to GetUserDetailsAsync.");

            var response = await _userService.GetClientDetailsAsync(id, cancellationToken);
            return response;
        }
    }
}
