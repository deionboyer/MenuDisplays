using MenuItems.DataAccess.EF.Repositories;
using MenuItems.Database.EF.Context;
using MenuItems.Database.EF.Models;

namespace Menus.Models
{
    public class ItemsViewModel
    {
        private ItemsRepository _repo;
        public List<Items> ItemList { get; set; }
        public Items CurrentItem { get; set; }
        public bool IsActionSuccess {  get; set; }
        public string ActionMessage {  get; set; }
        public ItemsViewModel(MenuItemsContext context)
        {
            _repo = new ItemsRepository(context);
            ItemList = GetAllItems();
            CurrentItem = ItemList.FirstOrDefault();
        }
        public ItemsViewModel(MenuItemsContext context, int itemID)
        {
            _repo = new ItemsRepository(context);
            ItemList = GetAllItems();
            if (itemID > 0)
            {
                CurrentItem = GetItem(itemID);
            }
            else
            {
                CurrentItem = new Items();
            }
        }
        public void SaveItem(Items item)
        {
            if(item.ItemID > 0)
            {
                _repo.Update(item);
            }
            else
            {
                _repo.Create(item);
            }
            ItemList = GetAllItems();
            CurrentItem = GetItem(item.ItemID);
        }
        public void DeleteItem(int itemID)
        {
            _repo.Delete(itemID);
            ItemList = GetAllItems();
            CurrentItem = ItemList.FirstOrDefault();
        }
        public List<Items> GetAllItems()
        {
            return _repo.GetAllItems();
        }
        public Items GetItem(int id)
        {
            return _repo.GetItemByID(id);
        }
        public void Add(int id)
        {
            
        }
    }
}
