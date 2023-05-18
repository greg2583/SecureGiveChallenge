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

        public IActionResult Update(int UserId)
        {
            User user = SampleData.UsersList.Where(k => k.UserId == UserId).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user, int UserId)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    SampleData.Update(user, UserId);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is NullReferenceException)
                    {
                        return View();
                    }                    
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
                

        }

        [HttpPost]
        public IActionResult Delete(int UserId)
        {
            
            User? user = SampleData.UsersList.FirstOrDefault(k => k.UserId == UserId);
            if (user != null)
            {
                SampleData.Delete(user);
            }            
            return RedirectToAction("Index");
        }
    }
}
