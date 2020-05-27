using SampleApp.Core.Entities;
using SampleApp.Core.Models.DTOs;

namespace SampleApp.Core.Models.Mappers
{
    public static class ClientDTOMapper
    {
        public static ClientDTO ToDTO(this Client entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new ClientDTO()
            {
                ClientId = entity.ClientId,
                Name = entity.Name,
                Age = entity.Age,
                Gender = entity.Gender
            };
        }
    }
}
