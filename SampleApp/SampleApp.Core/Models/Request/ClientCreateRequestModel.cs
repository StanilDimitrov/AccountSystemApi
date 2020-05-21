using SampleApp.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Core.Models.Request
{
    public class ClientCreateRequestModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(18, 80)]
        public int Age { get; set; }

        public GenderType? Gender { get; set;  }
    }
}
