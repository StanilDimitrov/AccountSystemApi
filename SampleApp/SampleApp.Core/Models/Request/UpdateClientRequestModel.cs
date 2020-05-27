using SampleApp.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Core.Models.Request
{
    public class UpdateClientRequestModel
    {
        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80.")]
        public int? Age { get; set; }
        public GenderType? Gender { get; set; }
    }
}
