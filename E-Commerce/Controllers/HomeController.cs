using E_Commerce.Database;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext _context;
        public HomeController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Customer customer)
        {
            
            var data = _context.Customers.FirstOrDefault(x => x.Email == customer.Email);
            if (data != null)
            {
                //ModelState.AddModelError("Email", "This email is already in use.");
                return RedirectToAction("SignUp", "Home");
            }
            
            else
            {
                _context.Customers.Add(new Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Password = customer.Password,
                    PhoneNumber = customer.PhoneNumber,
                    City = customer.City,
                    ZipCode = customer.ZipCode,
                    Address = customer.Address,
                });

                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult LogInAuth(Customer customer)
        {
            var data =_context.Customers.FirstOrDefault(x=>x.Email == customer.Email && x.Password== customer.Password);
            
            if(data!= null)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }
            
            
        }
    }
}