using MediatR;
using SampleApp.Core.Enums;
using SampleApp.Core.Models.DTOs;

namespace SampleApp.Core.Contract
{
    public class AddFundsToAccountCommand : IRequest<int>
    {
        public decimal Sum { get; set; }

        public AccountType AccountType { get; set; }

        public int ClientId { get; set; }
    }
}
