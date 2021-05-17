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

        public bool UpdateExistingMenuItem(string originalItem, MenuItems newItem)
        {
            MenuItems oldItem = GetItemsByName(originalItem);

            if(oldItem != null)
            {
                oldItem.MealName = newItem.MealName;
                oldItem.MealDescription = newItem.MealName;
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.ListOfIngredients = newItem.ListOfIngredients;
                oldItem.Price = newItem.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveMenuItemFromList(string itemName)
        {
            MenuItems item = GetItemsByName(itemName);

            if(item == null)
            {
                return false;
            }

            int initialCount = _menuInfo.Count;
            _menuInfo.Remove(item);

            if(initialCount > _menuInfo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public MenuItems GetItemsByName(string itemName)
        {
            foreach (MenuItems item in _menuInfo)
            {
                if (item.MealName.ToLower() == itemName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
