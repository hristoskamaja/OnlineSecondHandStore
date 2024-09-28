using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Secondhand_Store.Models
{
    public class Clothing
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        
    }
}