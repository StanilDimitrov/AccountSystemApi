using SampleApp.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApp.Core.Entities
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Sum { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
