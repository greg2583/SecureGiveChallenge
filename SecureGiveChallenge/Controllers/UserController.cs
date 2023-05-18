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
            SampleData.Create(user);
            return View("Thanks", user);
        }


    }
}
