using SampleApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Core.Models.Request
{
    public class ClientUpdateRequestModel
    {
        public int? Age { get; set; }
        public GenderType? Gender { get; set; }
    }
}
