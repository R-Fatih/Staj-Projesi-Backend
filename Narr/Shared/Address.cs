using Narevim.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narevim.Shared
{
    public class Address
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? email { get; set; }
        public string? telephone { get; set; }
        public string? clear_address { get; set; }
        public int? city_id { get; set; }
        public int? town_id { get; set; }
        public string? billing_name { get; set; }
        public string? billing_surname { get; set; }
        public string? billing_email { get; set; }
        public string? billing_telephone { get; set; }
        public string? billing_clear_address { get; set; }
        public int? billing_city_id { get; set; }
        public int? billing_town_id { get; set; }
        public string? user_id { get; set; }
        public City? city { get; set; }
        public Town? town { get; set; }
        public City? billing_city { get; set; }
        public Town? billing_town { get; set; }
        [NotMapped]
        public ApplicationUser?   User { get; set; }
    }
}
