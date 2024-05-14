using MenuItems.Database.EF.Context;
using MenuItems.Database.EF.Models;
using MenuItems.Database.EF.Repositories;

namespace Menus.Models
{
    public class MenuTypesViewModel
    {
        private MenuTypesRepository _repo;
        public List<MenuTypes> MenuList { get; set; }
        public MenuTypes CurrentMenu { get; set; }
        public bool IsActionSuccess {  get; set; }
        public string ActionMessage {  get; set; }
        public MenuTypesViewModel(MenuItemsContext context)
        {
            _repo = new MenuTypesRepository(context);
            MenuList = GetAllMenus();
            CurrentMenu = MenuList.FirstOrDefault();
        }
        public MenuTypesViewModel(MenuItemsContext context, int menuID)
        {
            _repo = new MenuTypesRepository(context);
            MenuList = GetAllMenus();
            if (menuID > 0)
            {
                CurrentMenu = GetMenu(menuID);
            }
            else
            {
                CurrentMenu = new MenuTypes();
            }
        }
        public void SaveMenu(MenuTypes menuTypes)
        {
            if(menuTypes.MenuID > 0)
            {
                _repo.Update(menuTypes);
            }
            else
            {
                _repo.Create(menuTypes);
            }
            MenuList = GetAllMenus();
            CurrentMenu = GetMenu(menuTypes.MenuID);
        }
        public void DeleteMenu(int id)
        {
            _repo.Delete(id);
            MenuList = GetAllMenus();
            CurrentMenu = MenuList.FirstOrDefault();
        }
        public List<MenuTypes> GetAllMenus()
        {
            return _repo.GetAllMenus();
        }
        public MenuTypes GetMenu(int id)
        {
            return _repo.GetMenuByID(id);
        }
        
    }
}
