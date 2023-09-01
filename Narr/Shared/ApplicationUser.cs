
using Microsoft.AspNetCore.Identity;

namespace Narevim.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? member_code { get; set; }
        public int? member_type { get; set; }
        public string? identity { get; set; }
        public string? name { get; set; }
        public string? second_name { get; set; }
        public string? surname { get; set; }
        public string? telephone { get; set; }
        public string? tax_address { get; set; }
        public string? tax_number { get; set; }
        public int? special_cargo { get; set; }
        public int? token { get; set; }
        public int? isNews { get; set; }
        public int? isActive { get; set; }
        public int? isStandartCargo { get; set; }
        public int? isSpecialCargo { get; set; }
        public DateTime? createdAt { get; set; }
    }
}