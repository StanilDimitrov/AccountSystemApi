using MediatR;
using SampleApp.Core.Enums;
using SampleApp.Core.Models.DTOs;

namespace SampleApp.Core.Contract
{
    public class UpdateAccountCommand : IRequest<AccountDTO>
    {
        public int AccountId { get; set; }

        public decimal? Sum { get; set; }

        public AccountType? AccountType { get; set; }
    }
}
