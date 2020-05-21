using SampleApp.Core.Models.Query;
using SampleApp.Core.Models.Request;
using SampleApp.Core.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Core.Dal.Contracts
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserCreateRequestModel request, CancellationToken cancellationToken);

        Task<UserResponseModel> GetUserDetailsAsync(int id, CancellationToken cancellationToken);

        Task UpdateUserAsync(int id, UserUpdateRequestModel request, CancellationToken cancellationToken);

        Task DeleteUserAsync(int id, CancellationToken cancellationToken);

        Task<QueryResult<UserResponseModel>> GetUserGridAsync(string name, int? age, CancellationToken cancellationToken);
    }
}
