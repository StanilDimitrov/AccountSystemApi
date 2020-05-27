using MediatR;
using SampleApp.Core.Enums;
using SampleApp.Core.Models.DTOs;

namespace SampleApp.Core.Contract
{
    public class CreateClientCommand : IRequest<ClientDTO>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public GenderType? Gender { get; set; }
    }
}
