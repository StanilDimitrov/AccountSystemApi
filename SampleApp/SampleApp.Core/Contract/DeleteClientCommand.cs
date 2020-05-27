using MediatR;
using SampleApp.Core.Models.DTOs;

namespace SampleApp.Core.Contract
{
    public class DeleteClientCommand : IRequest<ClientDTO>
    {
        public int ClientId { get; set; }
    }
}
