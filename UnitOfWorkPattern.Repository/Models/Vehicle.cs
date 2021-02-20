using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SWDCarRental.Models
{
    public partial class Vehicle
    {
        public int VelNo { get; set; }
        public int? CateId { get; set; }
        public string VehicleFare { get; set; }
        public int? Seat { get; set; }
        public string DescriptionCar { get; set; }
        public bool? Status { get; set; }
        public string ImageLink { get; set; }
        public string LicensePlates { get; set; }
        public string Brand { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? GarageId { get; set; }

        public virtual Category Cate { get; set; }
        public virtual Garage Garage { get; set; }
        public virtual BookingDetail VelNoNavigation { get; set; }
    }
}
