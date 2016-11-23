using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood2.Models;
using OdeToFood2.Services;
using OdeToFood2.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public HomeController(IRestaurantData restaurant, IGreeter greeter)
        {
            _restaurant = restaurant;
            _greeting = greeter;
        }

        public IGreeter _greeting { get; private set; }
        private IRestaurantData _restaurant { get; set; }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurant.GetAll();
            model.CurrentMessage = _greeting.GetGreeting();       
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _restaurant.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            return View(model);
        }

        

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.Name = model.Name;

                newRestaurant = _restaurant.Add(newRestaurant);
                _restaurant.Commit();
            

            return RedirectToAction("Details", new { id = newRestaurant.Id });
            }

            return View();


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurant.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var restaurant = _restaurant.Get(id);

            if (ModelState.IsValid)
            {
                restaurant.Cuisine = model.Cuisine;
                restaurant.Name = model.Name;
                _restaurant.Commit();

                return RedirectToAction("Details", new { id = restaurant });
            }

            return View(restaurant);
        }

    }
}
