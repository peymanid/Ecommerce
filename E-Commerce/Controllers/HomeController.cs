using E_Commerce.Database;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.GlobalState;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Basket()
        {
            var custId = _globalStateService.userId;
            var basketItems = _context.Baskets.Include(b => b.Product).Where(x => x.CustomerId == custId).ToList();
            return View(basketItems);
        }
        public IActionResult LogOut()
        {
            _globalStateService.userId = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddToBasket(int id)
        {
            if (_globalStateService.userId != null)
            {
                var custId = _globalStateService.userId;

                var basketItem = new Basket
                {
                    ProductId = id,
                    CustomerId = (int)custId
                };
                var toBasket = _context.Baskets.Add(basketItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
        }

        public IActionResult RemoveFromBasket(int id)
        {
            var itemToRemove = _context.Baskets.FirstOrDefault(x => x.BasketId == id);
            _context.Remove(itemToRemove);
            _context.SaveChanges();

            return RedirectToAction("Basket", "Home");
        }

    }
}
