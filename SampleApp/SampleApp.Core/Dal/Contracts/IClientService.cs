using SampleApp.Core.Models.Query;
using SampleApp.Core.Models.Request;
using SampleApp.Core.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal.Contracts
{
    public interface IClientService
    {
        Task<int> CreateCleintAsync(ClientCreateRequestModel request, CancellationToken cancellationToken);

        Task<ClientResponseModel> GetClientDetailsAsync(int id, CancellationToken cancellationToken);

        Task UpdateClientAsync(int id, ClientUpdateRequestModel request, CancellationToken cancellationToken);

        Task DeleteUserAsync(int id, CancellationToken cancellationToken);

        Task<QueryResult<ClientResponseModel>> GetClientGridAsync(string name, int? age, CancellationToken cancellationToken);
    }
}
