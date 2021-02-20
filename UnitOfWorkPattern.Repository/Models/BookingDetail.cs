using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SWDCarRental.Models
{
    public partial class BookingDetail
    {
        public int Id { get; set; }
        public int ResId { get; set; }
        public int VelNo { get; set; }
        public double? AmountOfMoney { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual Booking Res { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
