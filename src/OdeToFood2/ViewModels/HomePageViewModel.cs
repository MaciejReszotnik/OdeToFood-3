using OdeToFood2.Models;
using System.Collections.Generic;

namespace OdeToFood2.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
