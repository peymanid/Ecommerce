using E_Commerce.Database;
using E_Commerce.GlobalState;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class SignInController : Controller
    {
        private DatabaseContext _context;
        private IGlobalStateService _globalStateService;
        public SignInController (DatabaseContext context, IGlobalStateService globalStateService) 
        {
            _context = context;
            _globalStateService = globalStateService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogInAuth(Customer customer) 
        {
            var data = _context.Customers.FirstOrDefault(x => x.Email == customer.Email && x.Password == customer.Password);
            if (data != null)
            {
                _globalStateService.userId = data.CustomerId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }

        }
    }
}
