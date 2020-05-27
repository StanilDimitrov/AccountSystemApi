using SampleApp.Core.Contract;
using SampleApp.Core.Models.Request;

namespace SampleApp.Core.Models.Mappers
{
    public static class AddFundsToAccountRequestToCommandMapper
    {
        public static AddFundsToAccountCommand ToAddFundsToAccountCommand(this AddFundsToAccountRequestModel request, int clientId)
        {
            if (request is null)
            {
                return null;
            }

            return new AddFundsToAccountCommand()
            {
                Sum = request.Sum,
                AccountType = request.AccountType,
                ClientId = clientId
            };
        }
    }
}
