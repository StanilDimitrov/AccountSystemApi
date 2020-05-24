using SampleApp.Core.Enums;

namespace SampleApp.Core.Models.Request
{
    public class ClientUpdateRequestModel
    {
        public int? Age { get; set; }
        public GenderType? Gender { get; set; }
    }
}
