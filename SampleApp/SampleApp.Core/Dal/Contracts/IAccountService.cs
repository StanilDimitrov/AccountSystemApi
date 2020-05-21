using SampleApp.Core.Models.Request;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal.Contracts
{
    public interface IAccountService
    {
        Task<int> AddFundsToClientAccountAsync(int id, AddFundsToAccountRequestModel requestModel, CancellationToken cancellationToken);

        Task<int> UpdateAccountAsync(int id, UpdateAccountRequestModel requestModel, CancellationToken cancellationToken);
    }
}

