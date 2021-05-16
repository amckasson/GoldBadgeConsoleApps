using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class MenuItemsTests
    {
        [TestMethod]
        public void SetMenuName_ShouldSetCorrectString()
        {
            MenuItems item = new MenuItems();

            item.MealName = "Burger";

            string expected = "Burger";
            string actual = item.MealName;

            Assert.AreEqual(expected, actual);
        }
    }
}
