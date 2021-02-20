using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SWDCarRental.Models
{
    public partial class Category
    {
        public Category()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int CateId { get; set; }
        public string Colour { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
