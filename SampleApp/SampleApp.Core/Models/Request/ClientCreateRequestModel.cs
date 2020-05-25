using SampleApp.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Core.Models.Request
{
    public class ClientCreateRequestModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be between 2 and 100 characters long.")]
        [MaxLength(100, ErrorMessage = "Name must be between 2 and 100 characters long.")]
        public string Name { get; set; }

        [Required]
        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80.")]
        public int Age { get; set; }

        public GenderType? Gender { get; set;  }
    }
}
