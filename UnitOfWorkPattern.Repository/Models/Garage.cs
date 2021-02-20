using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SWDCarRental.Models
{
    public partial class Garage
    {
        public Garage()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int GarageId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
