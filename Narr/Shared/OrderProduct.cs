using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class OrderProduct
    {
        public int id { get; set; }
        public string order_number { get; set; }
        public int product_id { get; set; }
        public int? qty { get; set; }
        public Product? Product { get; set; }
    }
}
