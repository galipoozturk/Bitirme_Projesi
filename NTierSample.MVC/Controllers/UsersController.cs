using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTierSample.BLL.Abstract;
using NTierSample.DAL.Concrete;
using NTierSample.Model.Entities;

namespace NTierSample.MVC.Controllers
{
    public class UsersController : Controller
    {
        public readonly IUserBLL _userBll;

        public UsersController(IUserBLL user)
        {
            _userBll = user;
        }


        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Password,FirstName,LastName,")] User user)
        {
            if (ModelState.IsValid)
            {
                _userBll.Insert(user);
                return RedirectToAction("Index","Home");
            }
            return View(user);
        }

       
    }
}
