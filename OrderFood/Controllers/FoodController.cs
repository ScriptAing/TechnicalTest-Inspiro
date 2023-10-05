using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    public class FoodController : Controller
    {
        private readonly OrderFoodDbContext _context;

        public FoodController(OrderFoodDbContext context)
        {
            _context = context;
        }

        private static List<Food> GetFoods = new()
        {            
            new Food { Id = 1, Name = "Ketoprak", Description = "Makanan Ketoprak", Price = 15000 },
            new Food { Id = 2, Name = "Gado Gado", Description = "Makanan Gado Gado", Price = 15000 },
            new Food { Id = 3, Name = "Fried Chicken", Description = "Makanan Gado Gado", Price = 10000 },
            new Food { Id = 4, Name = "Gorengan", Description = "Cemilan Gorengan", Price = 1000 },
            new Food { Id = 5, Name = "Nasi Padang", Description = "Masakan Padang Paket", Price = 25000 }
        };

        // GET: Food
        public async Task<IActionResult> Index(string searchString)
        {
            if (GetFoods == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var foods = from m in GetFoods
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(s => s.Name!.Contains(searchString));
            }

            return View(foods);
        }

        // GET: Food/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || GetFoods == null)
            {
                return NotFound();
            }

            //var food = GetFoods.Where(m => m.Id == id);

            var foods = from m in GetFoods where m.Id == id
                        select m;

            var food = foods.FirstOrDefault();

            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }
    }
}
