using SampleApp.Core.Enums;
using SampleApp.Core.Models.Internal;
using System.Collections.Generic;

namespace SampleApp.Core.Models.Response
{
    public class ClientResponseModel
    {
        public string Name { get; set; }
        
        public int Age { get; set; }

        public GenderType? Gender { get; set; }

        public ICollection<AccountDetailsModel> Accounts { get; set; }
    }
}
