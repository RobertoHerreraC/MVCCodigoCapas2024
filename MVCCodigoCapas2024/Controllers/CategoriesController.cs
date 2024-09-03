using Domain;
using Infraestructure;
using Microsoft.AspNetCore.Mvc;
using MVCCodigoCapas2024.Models;
using Services;

namespace MVCCodigoCapas2024.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly MarketContext _context;
        private CategoryService _service;

        public CategoriesController(MarketContext context)
        {
            _context = context;
            _service = new CategoryService(_context);
        }

        public IActionResult Index()
        {
            var categories = _service.Get();

            var model = categories.Select(x => new CategoryModel
            {
                ID = x.CategoryID,
                Name = x.Name,
                Description = x.Description,
            }).ToList(); ;
            
            return View(model);
        }

        public IActionResult IndexAjax()
        {
            return View();
        }

        public IActionResult GetFilterCategories(string name)
        {
            var categories = _service.GetByFilterName(name);
            var model = categories.Select(x => new CategoryModel
            {
                ID = x.CategoryID,
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            return Json(model);
        }
    
    }
}
