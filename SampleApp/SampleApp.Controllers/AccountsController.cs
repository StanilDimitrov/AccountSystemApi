using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.Request;
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
        private readonly IAccountService _accountService;

        public AccountsController(ILogger<AccountsController> logger, IAccountService accountService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        // POST: api/Accounts/5
        [HttpPost]
        public async Task<ActionResult<int>> AddFundsToClinetAsync(int id, AddFundsToAccountRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to AddFundsToClinetAsync.");

            var accountId = await _accountService.AddFundsToClientAccountAsync(id, request, cancellationToken);

            return accountId;
        }

        // PUT: api/Accounts/5
        [HttpPut]
        public async Task<ActionResult> UpdateAccountAsync(int id, UpdateAccountRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call made to UpdateAccountAsync.");

            await _accountService.UpdateAccountAsync(id, request, cancellationToken);

            return Ok();
        }
    }
}
