using Microsoft.AspNetCore.Mvc;
using WebApplication051024_Product.Models;

namespace WebApplication051024_Product.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, ProductName = "Sample Product", Price = 99.99m, Description = "Sample Description" }
    };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            return RedirectToAction("Index");
        }
    }
}
