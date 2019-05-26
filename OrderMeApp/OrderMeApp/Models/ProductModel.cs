using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMeApp.Models
{
    public class ProductModel
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }     
        public decimal Price { get; set; }

    }
}
