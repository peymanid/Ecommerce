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
        public SignUpController(DatabaseContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
         {
                return View();
         }
        public IActionResult Registration(Customer customer)
        {
            
            if (ModelState.IsValid)
            {
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
            return View("Index");
        }
    }
}