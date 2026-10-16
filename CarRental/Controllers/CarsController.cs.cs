using Microsoft.AspNetCore.Mvc;
using CarRentalApp.Models;

namespace CarRentalApp.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto", PricePerDay = 3000 },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000 },
            new Car { Id = 3, Name = "Civic", PricePerDay = 8000 }
        };

        private static List<Car> bookedCars = new List<Car>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }

        [HttpPost]
        public IActionResult Book(int id)
        {
            var car = availableCars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                availableCars.Remove(car);
                bookedCars.Add(car);
                return RedirectToAction(nameof(Booked));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }
}