using SampleApp.Core.Entities;
using SampleApp.Core.Models.DTOs;

namespace SampleApp.Core.Models.Mappers
{
    public static class AccountDTOMapper
    {
        public static AccountDTO ToDTO(this Account entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new AccountDTO()
            {
                AccountId = entity.AccountId,
                Sum = entity.Sum,
                Type = entity.Type,
                ClientId = entity.ClientId
            };
        }
    }
}
