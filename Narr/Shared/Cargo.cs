using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class Cargo
    {
        public int id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string?   description { get; set; }
        public string? img_url { get; set; }
        public int? increase_desi { get; set; }
        public int? rank { get; set; }
        public int? isActive { get; set; }
        public DateTime? createdAt { get; set; }
    }
}
