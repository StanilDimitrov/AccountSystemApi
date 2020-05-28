using MediatR;
using SampleApp.Core.Enums;
using SampleApp.Core.Models.DTOs;

namespace SampleApp.Core.Contract.AccountsCommand
{
    public class UpdateClientCommand : IRequest<ClientDTO>
    {
        public int ClientId { get; set; }
        public int? Age { get; set; }
        public GenderType? Gender { get; set; }
    }
}
