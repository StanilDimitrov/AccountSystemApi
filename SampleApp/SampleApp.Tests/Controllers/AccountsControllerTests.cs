using AutoFixture;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SampleApp.Controllers;
using SampleApp.Core.Contract;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.DTOs;
using SampleApp.Core.Models.Request;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Tests.Controllers
{
    public class AccountsControllerTests
    {
        private Mock<ILogger<AccountsController>> _mockLogger;
        private Mock<IMediator> _mockMediator;
        private static Fixture _fixture;
        private static readonly CancellationToken CToken = CancellationToken.None;
        private static AccountsController _accountsController;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<AccountsController>>();
            _mockMediator = new Mock<IMediator>();
            _accountsController = new AccountsController(_mockLogger.Object, _mockMediator.Object);
            _fixture = new Fixture();
        }

        #region AddFundsToAccountAsync
        [Test]
        public async Task AddFundsToAccountAsync_Success()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<AddFundsToAccountCommand>(), CToken)).ReturnsAsync(It.IsAny<int>).Verifiable();

            var requestModel = _fixture.Create<AddFundsToAccountRequestModel>();
            var id = _fixture.Create<int>();

            var result = await _accountsController.AddFundsToClinetAsync(id, requestModel, CToken);

            var objectResult = result as ObjectResult;

            Assert.AreEqual(StatusCodes.Status201Created, objectResult.StatusCode);
            _mockMediator.Verify();
        }
        #endregion

        #region UpdateAccountAsync
        [Test]
        public async Task UpdateAccountAsync_Success()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<UpdateAccountCommand>(), CToken)).ReturnsAsync(It.IsAny<AccountDTO>).Verifiable();

            var requestModel = _fixture.Create<UpdateAccountRequestModel>();
            var id = _fixture.Create<int>();

            var result = await _accountsController.UpdateAccountAsync(id, requestModel, CToken);

            var objectResult = result as StatusCodeResult;

            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsInstanceOf(typeof(ActionResult), result);
            _mockMediator.Verify();
        }
        #endregion
    }
}
