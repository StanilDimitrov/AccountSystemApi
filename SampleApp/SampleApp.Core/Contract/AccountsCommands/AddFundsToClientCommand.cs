using MediatR;
using SampleApp.Core.Enums;

namespace SampleApp.Core.Contract.AccountsCommand
{
    public class AddFundsToClientCommand : IRequest<int>
    {
        public decimal Sum { get; set; }

        public AccountType Type { get; set; }

        public int ClientId { get; set; }
    }
}
