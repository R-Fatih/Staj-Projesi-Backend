using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public   class Town
    {
        public int id { get; set; }
        public string title { get; set; }
        public int cityid { get; set; }
        public City? City { get; set; }
    }
}
