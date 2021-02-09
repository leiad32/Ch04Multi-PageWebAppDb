using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phone_Contacts.Models;

namespace Phone_Contacts.Controllers
{
    public class PhoneController : Controller
    {
        private PhoneContext context { get; set; }

        public PhoneController(PhoneContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Phone());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var phone = context.Phones.Find(id);
            return View(phone);
        }

        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            if (ModelState.IsValid)
            {
                if (phone.PhoneId == 0)
                    context.Phones.Add(phone);
                else
                    context.Phones.Update(phone);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            } else
            {
                ViewBag.Action = (phone.PhoneId == 0) ? "Add" : "Edit";
                return View(phone);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var phone = context.Phones.Find(id);
            return View(phone);
        }

        [HttpPost]
        public IActionResult Delete(Phone phone)
        {
            context.Phones.Remove(phone);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
