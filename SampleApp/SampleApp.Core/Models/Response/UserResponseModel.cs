using SampleApp.Core.Enums;
using SampleApp.Core.Models.Internal;

namespace SampleApp.Core.Models.Response
{
    public class UserResponseModel
    {
        public string Name { get; set; }
        
        public int Age { get; set; }

        public GenderType? Gender { get; set; }

        public AccountDetailsModel AccountDetails { get; set; }
    }
}
