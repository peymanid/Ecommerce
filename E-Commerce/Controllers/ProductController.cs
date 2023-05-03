using E_Commerce.Database;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseContext _context;
        public ProductController(DatabaseContext context) {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var item = _context.Products.FirstOrDefault(x => x.ProductId == id);
            return View(item);
        }
    }
}
