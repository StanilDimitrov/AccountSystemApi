using SampleApp.Core.Enums;

namespace SampleApp.Core.Models.Request
{
    public class UpdateAccountRequestModel
    {
        public decimal? Sum { get; set; }

        public AccountType? AccountType { get; set; }
    }
}
