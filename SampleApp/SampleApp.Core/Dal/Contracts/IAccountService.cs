using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Models.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal.Contracts
{
    public interface IAccountService
    {
        Task<AccountDTO> AddFundsToClientAsync(AddFundsToClientCommand command, CancellationToken cancellationToken);

        Task<AccountDTO> UpdateAccountAsync(UpdateAccountCommand command, CancellationToken cancellationToken);
    }
}

