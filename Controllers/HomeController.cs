using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;//determina a dependencia da interface IPieRepository

        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IPieRepository pieRepository, ICategoryRepository categoryRepository)//constructor usando dependency injection feito no Startup(AddTransient)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

 
        // GET: /<controller>/
        public IActionResult Index()
        {


            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

           

            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to Bethany's Pie Shop",
                Pies = pies.ToList()
                
            };
            homeViewModel.CurrentCategory = "Cheese Cakes";
            return View(homeViewModel);

        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieByID(id);
            if (pie == null) return NotFound();
            
            return View(pie);
        }

    }

}
          
