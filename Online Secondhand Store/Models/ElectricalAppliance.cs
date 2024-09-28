using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Secondhand_Store.Models
{
    public class ElectricalAppliance
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Type { get; set; } // TV, Fridge, etc.
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
    }
}