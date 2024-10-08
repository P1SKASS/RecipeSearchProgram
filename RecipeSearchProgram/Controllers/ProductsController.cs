﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe_search_program.Models;
using System.ComponentModel;

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

        [HttpPost]
        public IActionResult UpdateEnable(int id, bool enable)
        {
            var existingProduct = _context.Products.Find(id);
            if (existingProduct != null)
            {
                existingProduct.Enable = enable;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }


        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product != null) {
                var existingProduct = await _context.Products
                    .FirstOrDefaultAsync(p => p.NameProduct == product.NameProduct);

                if (existingProduct != null)
                {
                    ModelState.AddModelError("NameProduct", "Such a product already exists.");
                    return View(product);
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(product.NameProduct, @"^[a-zA-Z\s]+$"))
                {
                    ModelState.AddModelError("NameProduct", "The product name must contain only Latin characters.");
                    return View(product);
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                return View(product);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> SearchRecipe(Product product)
        {
            return View();
        }

    }
}
