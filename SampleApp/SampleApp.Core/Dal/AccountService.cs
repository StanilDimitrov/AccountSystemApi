using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Data;
using SampleApp.Core.Models.Request;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal
{
    public class AccountService : IAccountService
    {
        private readonly AccountContext _context;

        public AccountService(AccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<int> AddFundsToClientAccountAsync(int id, AddFundsToAccountRequestModel requestModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAccountAsync(int id, UpdateAccountRequestModel requestModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
