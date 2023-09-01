using Narevim.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class Favoritte
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string user_id { get; set; }
        public Product? Product { get; set; }
        [NotMapped]
        public ApplicationUser   User { get; set; }
    }
}
