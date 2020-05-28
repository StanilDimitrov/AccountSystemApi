using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.DTOs;
using SampleApp.Handlers.Accounts;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Tests.Handlers.Accounts
{
    public class UpdateAccountCommandHandlerTests
    {
        private Mock<ILogger<UpdateAccountCommandHandler>> _mockLogger;
        private Mock<IAccountService> _mockAccountService;
        private static UpdateAccountCommandHandler _updateAccountCommandHandler;
        private static Fixture _fixture;
        private static readonly CancellationToken CToken = CancellationToken.None;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<UpdateAccountCommandHandler>>();
            _mockAccountService = new Mock<IAccountService>();
            _updateAccountCommandHandler = new UpdateAccountCommandHandler(_mockAccountService.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [Test]
        public async Task Handle_Success()
        {
            var command = _fixture.Create<UpdateAccountCommand>();
            var accountDTO = _fixture.Create<AccountDTO>();

            _mockAccountService.Setup(x => x.UpdateAccountAsync(command, CToken)).ReturnsAsync(accountDTO).Verifiable();

            var result = await _updateAccountCommandHandler.Handle(command, CToken);
            Assert.AreEqual(accountDTO, result);

            _mockAccountService.Verify();
        }
    }
}
