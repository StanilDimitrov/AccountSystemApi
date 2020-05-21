using SampleApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Core.Models.Request
{
    public class UserUpdateRequestModel
    {
        public int? Age { get; set; }
        public GenderType? Gender { get; set; }
    }
}
