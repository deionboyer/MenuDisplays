using MenuItems.Database.EF.Context;
using MenuItems.Database.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.Database.EF.Repositories
{
    public class MenuTypesRepository
    {
        private MenuItemsContext _context;
        private MenuItemsContext context;

        public MenuTypesRepository(MenuItemsContext context)
        {
            this.context = context;
        }

        public int Create(MenuTypes types)
        {
            _context.Add(types);
            _context.SaveChanges();
            return types.MenuID;
        }
        public int Update(MenuTypes types)
        {
            MenuTypes type = _context.MenuTypes.Find(types.MenuID);
            type.MenuID = types.MenuID;
            type.MenuType = types.MenuType;
            _context.SaveChanges();
            return types.MenuID;
        }
        public bool Delete(int menuID)
        {
            _context.Remove(menuID);
            _context.SaveChanges();
            return true;
        }
        public List<MenuTypes> GetAllMenus() 
        {
            List<MenuTypes> listMenus = new List<MenuTypes>();
            return listMenus;
        }
        public MenuTypes GetMenuByID(int menuID)
        {
            MenuTypes menu = _context.MenuTypes.Find(menuID);
            return menu;
        }
        
    }
}
