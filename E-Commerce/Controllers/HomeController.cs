using E_Commerce.Database;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.GlobalState;

namespace E_Commerce.Controllers
{

    public class HomeController : Controller
    {
        private DatabaseContext _context;
        private IGlobalStateService _globalStateService;
        public HomeController(DatabaseContext context, IGlobalStateService globalStateService)
        {
            _context = context;
            _globalStateService = globalStateService;
        }
        public IActionResult Index()
        {
            var productLists = new List<Product>();
            productLists = _context.Products.ToList();
            return View(productLists);
        }
        public IActionResult LogOut()
        {
            _globalStateService.userId = null;
            return RedirectToAction("Index");
        }
        public IActionResult AddToBasket(int id)
        {
            if (_globalStateService.userId != null)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == id);

                //Pass into basket

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
        }
    }
}
