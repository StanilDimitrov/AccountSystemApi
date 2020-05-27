using SampleApp.Core.Enums;

namespace SampleApp.Core.Models.DTOs
{
    public class ClientDTO
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public GenderType? Gender { get; set; }
    }
}
