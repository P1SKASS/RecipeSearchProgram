using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe_search_program.Models;

namespace Recipe_search_program.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SiteContex _context;

        public ProductsController(SiteContex context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
