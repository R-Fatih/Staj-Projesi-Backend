using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class Slider
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? title_color { get; set; }
        public string? description_color { get; set; }
        public int? title_size { get; set; }
        public int? description_size { get; set; }
        public string? img_url { get; set; }
        public int? allowButton { get; set; }
        public string? button_url { get; set; }
        public string? button_caption { get; set; }
        public string? block_side { get; set; }
        public string? animation_time { get; set; }
        public int? rank { get; set; }
        public int? isActive { get; set; }
        public DateTime? createdAt { get; set; }

    }
}
