using AutoFixture;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SampleApp.Controllers;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.DTOs;
using SampleApp.Core.Models.Query;
using SampleApp.Core.Models.Request;
using SampleApp.Core.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Tests.Controllers
{
    public class ClientsControllerTests
    {
        private Mock<ILogger<ClientsController>> _mockLogger;
        private Mock<IClientService> _mockClientService;
        private Mock<IMediator> _mockMediator;
        private static ClientsController _clientsController;
        private static Fixture _fixture;
        private static readonly CancellationToken CToken = CancellationToken.None;
     
        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<ClientsController>>();
            _mockClientService = new Mock<IClientService>();
            _mockMediator = new Mock<IMediator>();
            _clientsController = new ClientsController(_mockLogger.Object, _mockClientService.Object, _mockMediator.Object);
            _fixture = new Fixture();
        }

        #region CreateClientAsync
        [Test]
        public async Task CreateClientAsync_Success()
        {
            var clientId = _fixture.Create<int>();
            _mockMediator.Setup(x => x.Send(It.IsAny<CreateClientCommand>(), CToken)).ReturnsAsync(clientId).Verifiable();

            var requestModel = _fixture.Create<CreateClientRequestModel>();
            var result = await _clientsController.CreateClientAsync(requestModel, CToken);
            var objectResult = result as ObjectResult;

            Assert.AreEqual(StatusCodes.Status201Created, objectResult.StatusCode);
            _mockMediator.Verify();
        }
        #endregion

        #region UpdateClientAsync
        [Test]
        public async Task UpdateClientAsync_Success()
        {
            var requestModel = _fixture.Create<UpdateClientRequestModel>();
            var clientDTO = _fixture.Create<ClientDTO>();

            _mockMediator.Setup(x => x.Send(It.IsAny<UpdateClientCommand>(), CToken)).ReturnsAsync(clientDTO).Verifiable();
            var id = _fixture.Create<int>();
            var result = await _clientsController.UpdateClientAsync(id, requestModel, CToken);
            var statusResult = result as StatusCodeResult;

            Assert.AreEqual(StatusCodes.Status200OK, statusResult.StatusCode);
            Assert.IsInstanceOf(typeof(ActionResult), result);
            _mockMediator.Verify();
        }

        [Test]
        public async Task UpdateClientAsync_Returns_BadRequest()
        {
            var requestModel = _fixture.Build<UpdateClientRequestModel>()
                .Without(x => x.Age)
                .Without(x => x.Gender)
                .Create();

            var id = _fixture.Create<int>();
            var result = await _clientsController.UpdateClientAsync(id, requestModel, CToken);

            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }
        #endregion


        #region DeleteClientAsync
        [Test]
        public async Task DeleteClientAsync_Success()
        {
            var clientDTO = _fixture.Create<ClientDTO>();
            _mockMediator.Setup(x => x.Send(It.IsAny<DeleteClientCommand>(), CToken)).ReturnsAsync(clientDTO).Verifiable();

            var id = _fixture.Create<int>();
            var result = await _clientsController.DeleteClientAsync(id, CToken);
            var statusResult = result as StatusCodeResult;

            Assert.AreEqual(StatusCodes.Status200OK, statusResult.StatusCode);
            Assert.IsInstanceOf(typeof(ActionResult), result);
            _mockMediator.Verify();
        }
        #endregion

        #region GetClientsGridAsync
        [Test]
        public async Task GetClientsGridAsync_Success()
        {
            var name = _fixture.Create<string>();
            var age = _fixture.Create<int>();
            var queryResult = _fixture.Create<QueryResult<ClientResponseModel>>();

            _mockClientService.Setup(x => x.GetClientsGridAsync(name, age, CToken)).ReturnsAsync(queryResult).Verifiable();

            var id = _fixture.Create<int>();
            var result = await _clientsController.GetClientsGridAsync(name, age, CToken);

            Assert.IsInstanceOf(typeof(ActionResult<QueryResult<ClientResponseModel>>), result);
            _mockMediator.Verify();
        }
        #endregion

        #region GetClientDetailsAsync
        [Test]
        public async Task GetClientDetailsAsync_Success()
        {
            var id = _fixture.Create<int>();
            var responseModel = _fixture.Create<ClientResponseModel>();
            _mockClientService.Setup(x => x.GetClientDetailsAsync(id, CToken)).ReturnsAsync(responseModel).Verifiable();

            var result = await _clientsController.GetClientDetailsAsync(id, CToken);

            Assert.IsInstanceOf(typeof(ActionResult<ClientResponseModel>), result);
            _mockMediator.Verify();
        }
        #endregion
    }
}
