using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SWDCarRental.Models
{
    public partial class Account
    {
        public Account()
        {
        }

        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string Role { get; set; }
        public bool? Status { get; set; }
        public string GoogleId { get; set; }
        public string Password { get; set; }

    }
}
