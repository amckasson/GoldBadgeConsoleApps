using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class MenuItemsRepositoryTests
    {
        private MenuItemRepository _repo;
        private MenuItems _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            _item = new MenuItems(1, "Burger", "Traditional Handburger with your choice of cheese and garden", "Bun, Burger Patty, cheese, lettuce, tomato, pickle, onion", 7.5m);

            _repo.AddItemToList(_item);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange
            MenuItems item = new MenuItems();
            item.MealName = "Burger";
            MenuItemRepository repositroy = new MenuItemRepository();

            //Act
            repositroy.AddItemToList(item);
            MenuItems itemsFromMenu = repositroy.GetItemsByName("Burger");

            //Assert
            Assert.IsNotNull(itemsFromMenu);
        }

        [TestMethod]
        public void UpdateExistingItem_ShouldReturnTrue()
        {
            MenuItems newItem = new MenuItems(1, "Cheeseburger", "Traditional Cheeseburger with your choice of cheese and garden", "Bun, Burger Patty, cheese, lettuce, tomato, pickle, onion", 8.5m);

            bool updateResult = _repo.UpdateExistingMenuItem("Burger", newItem);

            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {

            bool deleteItem = _repo.RemoveMenuItemFromList(_item.MealName);

            Assert.IsTrue(deleteItem);
        }
    }
}
