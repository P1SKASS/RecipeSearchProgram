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
            List<Product> products;
            products = _context.Products.ToList();

            return View(products);
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product != null) {
                _context.Add(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                return View(product);
            }

            return RedirectToAction("List");
        }
    }
}
