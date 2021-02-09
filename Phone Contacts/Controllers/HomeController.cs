using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phone_Contacts.Models;

namespace Phone_Contacts.Controllers
{
    public class HomeController : Controller
    {
        private PhoneContext context { get; set; }
        public HomeController(PhoneContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var phones = context.Phones.OrderBy(p => p.Name).ToList();
            return View(phones);
        }
    }
}
