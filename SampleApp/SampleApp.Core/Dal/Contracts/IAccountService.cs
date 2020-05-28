using SampleApp.Core.Contract;
using SampleApp.Core.Entities;
using SampleApp.Core.Models.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal.Contracts
{
    public interface IAccountService
    {
        Task<AccountDTO> AddFundsToClientAccountAsync(AddFundsToAccountCommand command, CancellationToken cancellationToken);

        Task<AccountDTO> UpdateAccountAsync(UpdateAccountCommand command, CancellationToken cancellationToken);
    }
}

