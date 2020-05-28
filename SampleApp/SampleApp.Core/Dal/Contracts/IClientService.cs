using SampleApp.Core.Contract;
using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Entities;
using SampleApp.Core.Models.DTOs;
using SampleApp.Core.Models.Query;
using SampleApp.Core.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal.Contracts
{
    public interface IClientService
    {
        Task<Client> GetClientAsync(int clientId, CancellationToken cancellationToken);
        
        Task<ClientResponseModel> GetClientDetailsAsync(int id, CancellationToken cancellationToken);

        Task<ClientDTO> CreateClientAsync(CreateClientCommand command, CancellationToken cancellationToken);

        Task<ClientDTO> UpdateClientAsync(UpdateClientCommand command, CancellationToken cancellationToken);

        Task<ClientDTO> DeleteClientAsync(int id, CancellationToken cancellationToken);

        Task<QueryResult<ClientResponseModel>> GetClientsGridAsync(string name, int? age, CancellationToken cancellationToken);
    }
}
