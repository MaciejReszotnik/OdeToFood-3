using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood2.Models;
using OdeToFood2.Entities;

namespace OdeToFood2.Services
{
    public class SqlRestaurantData : IRestaurantData
    {

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public OdeToFoodDbContext _context { get; set; }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            
            return newRestaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }
    }
}
