using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SWDCarRental.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string ProfileImage { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IdentityCard { get; set; }
        public string FullName { get; set; }
        public string AccountId { get; set; }
        public bool? Status { get; set; }

        public virtual Account Account { get; set; }
    }
}
