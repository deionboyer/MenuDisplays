using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.Database.EF.Models
{
    public class MenuTypes
    {
        public int MenuID { get; set; }
        public string MenuType { get; set; }
        public MenuTypes() { }
        public MenuTypes(int menuID, string menuType)
        {
            MenuID = menuID;
            MenuType = menuType;
        }

    }
}
