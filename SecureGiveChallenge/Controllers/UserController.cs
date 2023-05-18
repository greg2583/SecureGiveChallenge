using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecureGiveChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace SecureGiveChallenge.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View(SampleData.UsersList);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                SampleData.Create(user);
                return View("Thanks", user);
            }
            else
            {
                return View();
            }                
        }

        public IActionResult Update(int ID)
        {
            User user = SampleData.UsersList.Where(k => k.UserId == ID).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user, int ID)
        {
            if (ModelState.IsValid)
            {
                SampleData.UsersList.Where(k => k.UserId == ID).FirstOrDefault().FirstName = user.FirstName;
                SampleData.UsersList.Where(k => k.UserId == ID).FirstOrDefault().LastName = user.LastName;
                SampleData.UsersList.Where(k => k.UserId == ID).FirstOrDefault().UserType = user.UserType;

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
                

        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            User user = SampleData.UsersList.Where(k => k.UserId == ID).FirstOrDefault();
            SampleData.Delete(user);            
            return RedirectToAction("Index");
        }
    }
}
