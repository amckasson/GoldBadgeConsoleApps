using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuItemRepository
    {
        private readonly List<MenuItems> _menuInfo = new List<MenuItems>();

        public void AddItemToList(MenuItems item)
        {
            _menuInfo.Add(item);
        }

        public List<MenuItems> GetMenuList()
        {
            return _menuInfo;
        }




        //Helper Method
        private MenuItems GetItemsByName(string )
    }
}
