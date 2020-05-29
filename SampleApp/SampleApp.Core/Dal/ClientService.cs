using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.CustomExceptions;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Data;
using SampleApp.Core.Entities;
using SampleApp.Core.Models.DTOs;
using SampleApp.Core.Models.Internal;
using SampleApp.Core.Models.Mappers;
using SampleApp.Core.Models.Query;
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

        public async Task<ClientDTO> CreateClientAsync(CreateClientCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = new Client
            {
                Name = command.Name,
                Age = command.Age,
                Gender = command.Gender
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync(cancellationToken);
            return client.ToDTO();
        }

        public async Task<ClientDTO> UpdateClientAsync(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = await GetClientAsync(command.ClientId, cancellationToken);

            SetClientProperties(client, command);
            await _context.SaveChangesAsync(cancellationToken);
            return client.ToDTO();
        }

        public async Task<ClientDTO> DeleteClientAsync(int clientId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = await GetClientAsync(clientId, cancellationToken);

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync(cancellationToken);
            return client.ToDTO();
        }

        public async Task<ClientResponseModel> GetClientDetailsAsync(int clientId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var clientResponse = await _context.Clients
                .Where(cl => cl.ClientId == clientId)
                .Include(cl => cl.Accounts)
                .Select(cl => new ClientResponseModel
                {
                    ClientId = cl.ClientId,
                    Name = cl.Name,
                    Age = cl.Age,
                    Gender = cl.Gender,
                    Accounts = cl.Accounts.Select(ac => new AccountDetailsModel
                    {
                        AccountId = ac.AccountId,
                        Sum = ac.Sum,
                        Type = ac.Type
                    }).ToList()
                }).SingleOrDefaultAsync(cancellationToken);

            if (clientResponse == null)
            {
                throw new NotFoundException($"Client with id: {clientId} does not exist.");
            }

            return clientResponse;
        }

        public async Task<QueryResult<ClientResponseModel>> GetClientsGridAsync(string name, int? age, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var clientsQuery = _context.Clients
                .Include(cl => cl.Accounts)
                .Select(cl => new ClientResponseModel
                {
                    ClientId = cl.ClientId,
                    Name = cl.Name,
                    Age = cl.Age,
                    Gender = cl.Gender,
                    Accounts = cl.Accounts.Select(ac => new AccountDetailsModel
                    {
                        AccountId = ac.AccountId,
                        Sum = ac.Sum,
                        Type = ac.Type
                    }).ToList()
                });

            clientsQuery = ApplyFilters(name, age, clientsQuery);
            var data = await clientsQuery.ToListAsync(cancellationToken);
            var total = await clientsQuery.CountAsync(cancellationToken);

            var queryResult = new QueryResult<ClientResponseModel>
            {
                Total = total,
                Data = data
            };

            return queryResult;
        }

        public async Task<Client> GetClientAsync(int clientId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var client = await _context.Clients.SingleOrDefaultAsync(cl => cl.ClientId == clientId, cancellationToken);

            if (client == null)
            {
                throw new NotFoundException($"Client with id: {clientId} does not exist.");
            }

            return client;
        }

        private void SetClientProperties(Client client, UpdateClientCommand command)
        {
            if (command.Age.HasValue)
            {
                client.Age = command.Age.Value;
            }

            if (command.Gender.HasValue)
            {
                client.Gender = command.Gender;
            }
        }

        private IQueryable<ClientResponseModel> ApplyFilters(string name, int? age, IQueryable<ClientResponseModel> query)
        {
            if (name != null)
            {
                query = query.Where(cl => cl.Name.ToLower().Contains(name.ToLower()));
            }
            if (age != null)
            {
                query = query.Where(cl => cl.Age == age);
            }

            return query;
        }
    }
}
