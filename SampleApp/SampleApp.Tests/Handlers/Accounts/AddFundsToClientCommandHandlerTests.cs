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
    public class AddFundsToClientCommandHandlerTests
    {
        private Mock<ILogger<AddFundsToClientCommandHandler>> _mockLogger;
        private Mock<IAccountService> _mockAccountService;
        private static AddFundsToClientCommandHandler _addFundsToClientCommandHandler;
        private static Fixture _fixture;
        private static readonly CancellationToken CToken = CancellationToken.None;
       
        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<AddFundsToClientCommandHandler>>();
            _mockAccountService = new Mock<IAccountService>();
            _addFundsToClientCommandHandler = new AddFundsToClientCommandHandler(_mockAccountService.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [Test]
        public async Task Handle_Success()
        {
            var command = _fixture.Create<AddFundsToClientCommand>();
            var accountDTO = _fixture.Create<AccountDTO>();

            _mockAccountService.Setup(x => x.AddFundsToClientAsync(command, CToken)).ReturnsAsync(accountDTO).Verifiable();

            var result = await _addFundsToClientCommandHandler.Handle(command, CToken);
            Assert.AreEqual(accountDTO.AccountId, result);

            _mockAccountService.Verify();
        }
    }
}
