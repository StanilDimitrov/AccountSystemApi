using SampleApp.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Core.Models.Request
{
    public class AddFundsToAccountRequestModel
    {
        [Required]
        public decimal Sum { get; set; }

        [Required]
        public AccountType Type { get; set; }
    }
}
