﻿using SampleApp.Core.Enums;

namespace SampleApp.Core.Models.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }

        public decimal Sum { get; set; }

        public AccountType Type { get; set; }

        public int ClientId { get; set; }
    }
}
