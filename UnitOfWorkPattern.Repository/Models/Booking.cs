using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SWDCarRental.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int ResId { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string AccountId { get; set; }
        public double TotalPayment { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
