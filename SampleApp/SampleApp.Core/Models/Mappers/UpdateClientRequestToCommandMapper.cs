using SampleApp.Core.Contract;
using SampleApp.Core.Models.Request;

namespace SampleApp.Core.Models.Mappers
{
    public static class UpdateClientRequestToCommandMapper
    {
        public static UpdateClientCommand ToUpdateClientCommand(this UpdateClientRequestModel request, int id)
        {
            if (request is null)
            {
                return null;
            }

            return new UpdateClientCommand()
            {
                ClientId = id,
                Age = request.Age,
                Gender = request.Gender
            };
        }
    }
}
