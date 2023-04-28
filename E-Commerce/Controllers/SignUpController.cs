using E_Commerce.Database;
using E_Commerce.GlobalState;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class SignUpController : Controller
    {
        private DatabaseContext _context;
        private IGlobalStateService _globalStateService;
        public SignUpController(DatabaseContext context, IGlobalStateService globalStateService) 
        {
            _context = context;
            _globalStateService = globalStateService;
        }
        public IActionResult Index()
         {
                return View();
         }
        public IActionResult Registration(Customer customer = null)
        {
            if (customer != null) { 
                var data = _context.Customers.FirstOrDefault(x => x.Email == customer.Email);
                if (data == null)
                {
                    _context.Customers.Add(new Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Password = customer.Password,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                 });
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("SignUp");
        }
    }
}
