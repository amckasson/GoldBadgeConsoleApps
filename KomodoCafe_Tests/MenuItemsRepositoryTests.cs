using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class MenuItemsRepositoryTests
    {
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            MenuItems item = new MenuItems();
            item.MealName = "Burger";
            MenuItemRepository repositroy = new MenuItemRepository();

            repositroy.AddItemToList(item);
            MenuItems itemsFromMenu = repositroy.GetItemsByName("Burger");

            Assert.IsNotNull(itemsFromMenu);
        }
    }
}
