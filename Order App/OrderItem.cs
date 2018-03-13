using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_App
{
    class OrderItem
    {
        public string stockCode { get; set; }
        public string description { get; set; }
        public string packSize { get; set; }
        public int quantity { get; set; }
    }
}
