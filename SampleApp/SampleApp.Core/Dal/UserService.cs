using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Models.Query;
using SampleApp.Core.Models.Request;
using SampleApp.Core.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal
{
    public class UserService : IUserService
    {
        public Task<int> CreateUserAsync(UserCreateRequestModel request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserResponseModel> GetUserDetailsAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserResponseModel>> GetUserGridAsync(string name, int? age, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUserAsync(int id, UserUpdateRequestModel request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        Task<QueryResult<UserResponseModel>> IUserService.GetUserGridAsync(string name, int? age, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
