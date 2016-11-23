using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood2.Models
{
    public enum CuisinesType
    {
        None,
        Italian,
        French,
        Japanese,
        American
    }
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, MaxLength(80)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        public CuisinesType Cuisine { get; set; }
    }
}
