using MediatR;
using SampleApp.Core.Enums;

namespace SampleApp.Core.Contract
{
    public class CreateClientCommand : IRequest<int>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public GenderType? Gender { get; set; }
    }
}
