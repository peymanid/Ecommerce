using E_Commerce.Database;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseContext _context;
        public ProductController(DatabaseContext context) 
        {
            _context= context;
        }
        
        public IActionResult Index()
        {
            var productLists = new List<Product>();
            productLists = _context.Products.ToList();
       
            return View(productLists);
        }


    }
}
