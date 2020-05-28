using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.DTOs;
using SampleApp.Handlers.Clients;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Tests.Clients.Handlers
{
    public class UpdateClientCommandHendlerTests
    {
        private Mock<ILogger<UpdateClientCommandHandler>> _mockLogger;
        private Mock<IClientService> _mockClientService;
        private static Fixture _fixture;
        private static readonly CancellationToken CToken = CancellationToken.None;
        private static UpdateClientCommandHandler _updateClientCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<UpdateClientCommandHandler>>();
            _mockClientService = new Mock<IClientService>();
            _updateClientCommandHandler = new UpdateClientCommandHandler(_mockClientService.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [Test]
        public async Task Handle_Success()
        {
            var command = _fixture.Create<UpdateClientCommand>();
            var clientDTO = _fixture.Create<ClientDTO>();

            _mockClientService.Setup(x => x.UpdateClientAsync(command, CToken)).ReturnsAsync(clientDTO).Verifiable();

            var result = await _updateClientCommandHandler.Handle(command, CToken);
            Assert.AreEqual(clientDTO, result);

            _mockClientService.Verify();
        }
    }
}
