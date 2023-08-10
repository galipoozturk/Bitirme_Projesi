using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTierSample.BLL.Abstract;
using NTierSample.DAL.Abstract;
using NTierSample.DAL.Concrete;
using NTierSample.Model.Entities;
using NTierSample.Model.Enums;

namespace NTierSample.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private IProductBLL _productBLL;

        public ProductsController(IProductBLL productBLL)
        {
            _productBLL = productBLL;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(_productBLL.GetAll());
        }

        // GET: Products/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_productBLL.Get((int)id));
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Name,Image")] Product product)
        {
            _productBLL.Insert(product);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productBLL.Get((int)id);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Image,ID,CreatedDate,IsActive")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

          
              _productBLL.Update(product);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productBLL.Get((int)id);
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _productBLL.DeleteByID(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
