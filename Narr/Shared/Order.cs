using Narevim.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class Order
    {
        public int id { get; set; }
        public string? order_number { get; set; }
        public string? total_amount { get; set; }
        public string? order_date { get; set; }
        public string? member_adress { get; set; }
        public string? order_state { get; set; }
      public  List<Product>? order_detail { get; set; }
        public int payment_id { get; set; }
        public int cargo_id { get; set; }
        public string order_note { get; set; }
        public string user_id { get; set; }
        [NotMapped]
        public ApplicationUser User { get; set; }

    }
}
