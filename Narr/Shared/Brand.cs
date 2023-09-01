using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class Brand
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? img_url { get; set; }
        public int? rank { get; set; }
        public int? isActive { get; set; }
        public DateTime? createdat { get; set; }
    }
}
