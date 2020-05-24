using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Data;
using SampleApp.Core.Entities;
using SampleApp.Core.Models.Internal;
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
        public async Task<int> CreateCleintAsync(ClientCreateRequestModel clientModel, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = new Client
            {
                Name = clientModel.Name,
                Age = clientModel.Age,
                Gender = clientModel.Gender
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync(cancellationToken);

            return client.ClientId;
        }

        public async Task UpdateClientAsync(int clientId, ClientUpdateRequestModel request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = await GetClientAsync(clientId, cancellationToken);

            SetClientProperties(client, request);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteUserAsync(int clientId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = await GetClientAsync(clientId, cancellationToken);

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ClientResponseModel> GetClientDetailsAsync(int clientId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = await GetClientAsync(clientId, cancellationToken);

            var clientAcounts = await _context.Accounts
                                    .Include(cl => cl.Client)
                                    .Where(cl => cl.ClientId == clientId)
                                    .Select(ca => new AccountDetailsModel
                                    {
                                        Sum = ca.Sum,
                                        AccountType = ca.AccountType
                                    })
                                    .ToListAsync(cancellationToken);
            if (client == null)
            {
                throw new ArgumentNullException();
            }

            var response = new ClientResponseModel
            {
                Name = client.Name,
                Age = client.Age,
                Gender = client.Gender,
                Accounts = clientAcounts
            };

            return response;
        }

        public Task<QueryResult<ClientResponseModel>> GetClientGridAsync(string name, int? age, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        private async Task<Client> GetClientAsync(int clientId, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == clientId, cancellationToken);

            if (client == null)
            {
                throw new ArgumentNullException();
            }

            return client;
        }

        private void SetClientProperties(Client client, ClientUpdateRequestModel requestModel)
        {
            if (requestModel.Age != null)
            {
                client.Age = (int)requestModel.Age;
            }

            if (requestModel.Gender != null)
            {
                client.Gender = requestModel.Gender;
            }
        }
    }
}
