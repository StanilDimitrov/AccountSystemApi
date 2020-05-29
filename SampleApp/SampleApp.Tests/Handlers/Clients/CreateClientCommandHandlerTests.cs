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
    public class CreateClientCommandHandlerTests
    {
        private Mock<ILogger<CreateClientCommandHandler>> _mockLogger;
        private Mock<IClientService> _mockClientService;
        private static CreateClientCommandHandler _createClientCommandHandler;
        private static Fixture _fixture;
        private static readonly CancellationToken CToken = CancellationToken.None;
        
        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<CreateClientCommandHandler>>();
            _mockClientService = new Mock<IClientService>();
            _createClientCommandHandler = new CreateClientCommandHandler( _mockClientService.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [Test]
        public async Task Handle_Success()
        {
            var command = _fixture.Create<CreateClientCommand>();
            var clientDTO = _fixture.Create<ClientDTO>();
            _mockClientService.Setup(x => x.CreateClientAsync(command, CToken)).ReturnsAsync(clientDTO).Verifiable();

            var result = await _createClientCommandHandler.Handle(command, CToken);

            Assert.AreEqual(clientDTO.ClientId, result);
            _mockClientService.Verify();
        }
    }
}
