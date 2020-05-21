using SampleApp.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Core.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(18, 80)]
        public int Age { get; set; }

        public GenderType? Gender { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
