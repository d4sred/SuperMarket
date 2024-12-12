using Microsoft.AspNetCore.Mvc;
using SuperMarket.Models;
using System.Collections.Generic;

namespace Supermarket.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Maçã", Price = 1.00M },
            new Product { Id = 2, Name = "Banana", Price = 0.50M },
            new Product { Id = 3, Name = "Laranja", Price = 0.75M }
        };

        /// <summary>
        /// Função da treta
        /// </summary>
        /// <param >
        /// Com param da tetra
        /// </param>
        /// <returns>
        /// Devolve uma view da treta
        /// </returns>
        public IActionResult List()
        {
            ViewData["Products"] = products;
            return View();
        }

        /// <summary>
        /// Função de um produto da treta
        /// </summary>
        /// <param name="id">
        /// Id de um produto da treta
        /// </param>
        /// <returns>
        /// Devolve a view do produto da treta
        /// </returns>
        public IActionResult Details(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null) return NotFound();

            ViewData["Product"] = product;
            return View();
        }

        public IActionResult ListJSON(int? id)
        {
            if (id == null)
                return Json(products);
            else
            {
                var product = products.Find(p => p.Id == id);
                if (product == null) return NotFound();
                return Json(product);
            }
        }
    }
}
