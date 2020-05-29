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
    public class DeleteClientCommandHandlerTests
    {
        private Mock<ILogger<DeleteClientCommandHandler>> _mockLogger;
        private Mock<IClientService> _mockClientService;
        private static DeleteClientCommandHandler _deleteClientCommandHandler;
        private static Fixture _fixture;
        private static readonly CancellationToken CToken = CancellationToken.None;
 
        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<DeleteClientCommandHandler>>();
            _mockClientService = new Mock<IClientService>();
            _deleteClientCommandHandler = new DeleteClientCommandHandler(_mockClientService.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [Test]
        public async Task Handle_Success()
        {
            var command = _fixture.Create<DeleteClientCommand>();
            var clientDTO = _fixture.Create<ClientDTO>();
            _mockClientService.Setup(x => x.DeleteClientAsync(command.ClientId, CToken)).ReturnsAsync(clientDTO).Verifiable();

            var result = await _deleteClientCommandHandler.Handle(command, CToken);

            Assert.AreEqual(clientDTO, result);
            _mockClientService.Verify();
        }
    }
}
