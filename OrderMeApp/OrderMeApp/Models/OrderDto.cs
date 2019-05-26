using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMeApp.Models
{
    public class OrderDto
    {
        public int ID { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public string CustomerId { get; set; }
        public string Customer { get; set; }       
        public string Description { get; set; }      
        public decimal Price { get; set; }
        public int Number { get; set; }        
        public DateTime OrderDate { get; set; }
        public Boolean isShipped { get; set; } = false;

   
      
    }
}
