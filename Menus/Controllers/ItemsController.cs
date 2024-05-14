using MenuItems.Database.EF.Context;
using MenuItems.Database.EF.Models;
using Menus.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menus.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MenuItemsContext _context;
        public ItemsController(MenuItemsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int itemID, string itemName, string description, decimal price)
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            Items items = new Items(itemID, itemName, description, price);
            model.SaveItem(items);
            model.IsActionSuccess = true;
            model.ActionMessage = "Added";
            return View(model);
        }
        public IActionResult Update(int id)
        {
            ItemsViewModel model = new ItemsViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            if(id > 0)
            {
                model.DeleteItem(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Deleted";
            return View("Index", model);
        }
    }
}
