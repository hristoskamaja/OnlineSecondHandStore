using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Secondhand_Store.Models
{
    public class CartItem
    {
        public int ItemId { get; set; } // Идентификатор за сите типови производи
        public string Category { get; set; } // Категорија на производот (Clothing, Car, Furniture, IT Equipment, Electrical Appliance, etc.)
        public string Name { get; set; } // Име или модел на производот
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
        public string ImageUrl { get; set; } // URL на сликата за производот
    }
}