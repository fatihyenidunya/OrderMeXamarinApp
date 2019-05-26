using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMeApp.Models
{
    public class ResponseData
    {
        public bool result { get; set; }
        public object data { get; set; }
        public string message { get; set; }

    }
}
