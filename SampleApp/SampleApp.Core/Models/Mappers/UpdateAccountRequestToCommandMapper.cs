using SampleApp.Core.Contract;
using SampleApp.Core.Models.Request;

namespace SampleApp.Core.Models.Mappers
{
    public static class UpdateAccountRequestToCommandMapper
    {
        public static UpdateAccountCommand ToUpdateAccountCommand(this UpdateAccountRequestModel request, int accountId)
        {
            if (request is null)
            {
                return null;
            }

            return new UpdateAccountCommand()
            {
                AccountId = accountId,
                Sum = request.Sum,
                AccountType = request.AccountType
            };
        }
    }
}
