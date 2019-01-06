using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Kayak";
            string productName = myProduct.Name;
            return View("Result", (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult UseExtention()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 35},
                    new Product {Name = "Lifejacket", Price = 35364},
                    new Product {Name = "Soccer ball", Price = 3467},
                    new Product {Name ="Corner flag", Price = 893}
                }
            };
            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product { Name = "Kayak", Category = "Watersports", Price = 275.52m },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.43m },
                    new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.75m },
                    new Product { Name = "Corner flag", Category = "Soccer", Price = 34.24m }
                }
            };
            //Func<Product, bool> categoryFilter = delegate (Product prod) {
            //    return prod.Category == "Soccer";
            //};

            Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            decimal total = 0;
            //foreach (Product prod in products.FilterByCategory("Soccer"))
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[] {
                new { Name = "MVC", Category = "Pattern"},
                new { Name = "Hat", Category = "Clothing"},
                new { Name = "Apple", Category = "Fruit"}
                };
            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }
            return View("Result", (object)result.ToString());
        }

        public ViewResult RazerIndex()
        {
            Product product = new Product
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "Watersport",
                Price = 275.67m
            };
            return View(product);
        }
    }
}


