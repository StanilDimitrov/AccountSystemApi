using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Models.Mappers;
using SampleApp.Core.Models.Request;
using SampleApp.Core.Models.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public AccountsController(ILogger<AccountsController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // POST: api/Accounts/5
        [HttpPost("{id}")]
        public async Task<ActionResult> AddFundsToClinetAsync(int id, AddFundsToAccountRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to AddFundsToClinetAsync.");

            var command = request.ToAddFundsToAccountCommand(id);

            var accountId = await _mediator.Send(command, cancellationToken);

            var response = new CreateAccountResponseModel { AccountId = accountId };

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAccountAsync(int id, UpdateAccountRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to UpdateAccountAsync.");

            var command = request.ToUpdateAccountCommand(id);

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
