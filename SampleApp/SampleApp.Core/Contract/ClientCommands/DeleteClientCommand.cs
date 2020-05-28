using MediatR;
using SampleApp.Core.Models.DTOs;

namespace SampleApp.Core.Contract.AccountsCommand
{
    public class DeleteClientCommand : IRequest<ClientDTO>
    {
        public int ClientId { get; set; }
    }
}
