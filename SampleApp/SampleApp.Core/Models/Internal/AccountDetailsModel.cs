using SampleApp.Core.Enums;

namespace SampleApp.Core.Models.Internal
{
    public class AccountDetailsModel
    {
        public int AccountId { get; set; }

        public decimal Sum { get; set; }

        public AccountType Type { get; set; }
    }
}
