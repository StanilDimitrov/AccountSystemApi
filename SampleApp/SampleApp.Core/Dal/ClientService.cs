using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Data;
using SampleApp.Core.Models.Query;
using SampleApp.Core.Models.Request;
using SampleApp.Core.Models.Response;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal
{
    public class ClientService : IClientService
    {
        private readonly AccountContext _context;

        public ClientService(AccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
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
