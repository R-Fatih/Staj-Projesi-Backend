using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class Category
    {
        public int id { get; set; }
        public string? url { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? facebook_pixel { get; set; }
        public string? free_pay_limit { get; set; }
        public string? icon { get; set; }
        public string? img_url { get; set; }
        public string?  banner_url { get; set; }
        public string? home_banner_url { get; set; }
        public int rank { get; set; }
        public int isActive { get; set; }
        public bool? isNext { get; set; }
        public DateTime? createdAt { get; set; }
        public int? first_group_id { get; set; }
        public int? second_group_id { get; set; }
        public int? third_group_id { get; set; }
    }
}
