using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.Query;
using SampleApp.Core.Models.Request;
using SampleApp.Core.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal
{
    public class UserService : IUserService
    {
        public Task<int> CreateCleintAsync(ClientCreateRequestModel request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ClientResponseModel> GetClientDetailsAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<QueryResult<ClientResponseModel>> GetClientGridAsync(string name, int? age, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateClientAsync(int id, ClientUpdateRequestModel request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
