using Narevim.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class Basket
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public int qty { get; set; }
        public string UserId { get; set; }
        public Product? Product { get; set; }
        [NotMapped]
        public ApplicationUser? User { get; set; }

    }
}
