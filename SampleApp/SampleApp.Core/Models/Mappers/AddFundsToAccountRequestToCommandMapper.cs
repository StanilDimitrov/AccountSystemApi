using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Models.Request;

namespace SampleApp.Core.Models.Mappers
{
    public static class AddFundsToAccountRequestToCommandMapper
    {
        public static AddFundsToClientCommand ToAddFundsToClientCommand(this AddFundsToAccountRequestModel request, int clientId)
        {
            if (request is null)
            {
                return null;
            }

            return new AddFundsToClientCommand()
            {
                Sum = request.Sum,
                AccountType = request.AccountType,
                ClientId = clientId
            };
        }
    }
}
