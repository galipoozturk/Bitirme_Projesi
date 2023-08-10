using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTierSample.BLL.Abstract;
using NTierSample.Model.Dto;
using NTierSample.Model.Entities;
using System.Collections;

namespace NTierSample.MVC.Controllers
{
    public class ShoppingListsController : Controller
    {
        private IShoppingListBLL _shoppingService;
        private IProductBLL _productService;

        public ShoppingListsController(IShoppingListBLL shoppingService, IProductBLL productService)
        {
            _shoppingService = shoppingService;
            _productService = productService;
        }

        // GET: ShoppingLists
        //[Authorize(Roles ="Admin")]
        [Authorize]

        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");
            string? userId = User.Claims.FirstOrDefault(s => s.Type == "user_id")?.Value;
            ICollection<ShoppingList> shoppingLists = _shoppingService.GetAllByUserId(int.Parse(userId));
            return View(shoppingLists);
        }

        // GET: ShoppingLists/Details/5
        [Authorize]

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string? userId = User.Claims.FirstOrDefault(s => s.Type == "user_id")?.Value;
            return View(_shoppingService.Get((int)id, int.Parse(userId)));
        }

        // GET: Users/Create
        [Authorize]

        public IActionResult Create()
        {
            ShoppingList dto = new ShoppingList();
            dto.Items = new List<ListItem>();
            _productService.GetAll().ToList().ForEach(s => dto.Items.Add(new ListItem
            {
                CreatedDate = DateTime.Now,
                Description = "",
                IsActive = false,
                Product = s,
                ProductId = s.ID
            }));
            return View(dto);
        }


        // POST: ShoppingLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public IActionResult Create([Bind("Name,Items")] ShoppingList dto)
        {
            //if (ModelState.IsValid)
            ShoppingList shoppingList = dto;
            string? userId = User.Claims.FirstOrDefault(s => s.Type == "user_id")?.Value;
            shoppingList.UserId = int.Parse(userId);
            dto.Items.RemoveAll(s => !s.IsActive);
            _shoppingService.Insert(shoppingList);
           
            return RedirectToAction(nameof(Index));

            //return View(shoppingList);
        }



        // GET: ShoppingLists/Edit/5
        [Authorize]

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string? userId = User.Claims.FirstOrDefault(s => s.Type == "user_id")?.Value;
            var shoppingList = _shoppingService.Get((int)id, int.Parse(userId));
            if (shoppingList == null)
            {
                return NotFound();
            }
            //            ViewData["UserId"] = new SelectList(_context.Users, "ID", "Email", shoppingList.UserId);
            return View(shoppingList);
        }

        // POST: ShoppingLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public IActionResult Edit(int id, [Bind("Name,ID")] ShoppingList shoppingList)
        {
            if (id != shoppingList.ID)
            {
                return NotFound();
            }

            _shoppingService.ChangeName(shoppingList.ID, shoppingList.Name);
            return RedirectToAction(nameof(Index));
        }
    }
}
