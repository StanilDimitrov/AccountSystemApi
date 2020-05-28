using SampleApp.Core.Contract.AccountsCommand;
using SampleApp.Core.Models.Request;

namespace SampleApp.Core.Models.Mappers
{
    public static class CreateClientRequestToCommandMapper
    {
        public static CreateClientCommand ToCreateClientCommand(this CreateClientRequestModel request)
        {
            if (request is null)
            {
                return null;
            }

            return new CreateClientCommand()
            {
                Name = request.Name,
                Age = request.Age,
                Gender = request.Gender
            };
        }
    }
}
