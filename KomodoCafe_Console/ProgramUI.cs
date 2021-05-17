using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuItemRepository _itemRepo = new MenuItemRepository();
        public void Run()
        {
            SeedMenuList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. View Menu Item By Name\n" +
                    "4. Update Menu Item\n" +
                    "5. Delete Menu Item\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                    case "one":
                        CreateNewMenuItem();
                        break;
                    case "2":
                    case "two":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                    case "three":
                        DisplayItemByName();
                        break;
                    case "4":
                    case "four":
                        UpdateExistingItem();
                        break;
                    case "5":
                    case "five":
                        DeleteExistingItem();
                        break;
                    case "6":
                    case "six":
                        Console.WriteLine("Have a great day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItems newItem = new MenuItems();

            Console.WriteLine("Enter the Meal Number.");
            string numberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(numberAsString);

            Console.WriteLine("Enter the Meal Name.");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the Meal Description.");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the List of Ingredients.");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the Price for the Meal.");
            string priceAsString = Console.ReadLine();
            newItem.Price = decimal.Parse(priceAsString);

            _itemRepo.AddItemToList(newItem);
        }

        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<MenuItems> listOfMenuItems = _itemRepo.GetMenuList();

            foreach(MenuItems item in listOfMenuItems)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal: {item.MealName}\n" +
                    $"Meal Description: {item.MealDescription}\n" +
                    $"Ingredients: {item.ListOfIngredients}\n" +
                    $"Price: {item.Price}");
            }
        }

        private void DisplayItemByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the Name of the Menu Item.");
            string itemName = Console.ReadLine();
            MenuItems item = _itemRepo.GetItemsByName(itemName);
            if(item != null)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal: {item.MealName}\n" +
                    $"Meal Description: {item.MealDescription}\n" +
                    $"Ingredients: {item.ListOfIngredients}\n" +
                    $"Price: {item.Price}");
            }
            else
            {
                Console.WriteLine("No Menu Items with that Name.");
            }
        }

        private void UpdateExistingItem()
        {
            DisplayAllMenuItems();
            Console.WriteLine("Enter the Menu Item you would like to Update.");
            string oldItem = Console.ReadLine();

            MenuItems newItem = new MenuItems();

            Console.WriteLine("Enter the Meal Number.");
            string numberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(numberAsString);

            Console.WriteLine("Enter the Meal Name.");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the Meal Description.");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the List of Ingredients.");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the Price for the Meal.");
            string priceAsString = Console.ReadLine();
            newItem.Price = decimal.Parse(priceAsString);

            bool wasUpdated = _itemRepo.UpdateExistingMenuItem(oldItem, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("Menu Item was updated.");
            }
            else
            {
                Console.WriteLine("Could not Update Menu Item.");
            }

        }

        private void DeleteExistingItem()
        {
            DisplayAllMenuItems();
            Console.WriteLine("\nEnter the Name of the Item you would like to Remove.");
            string input = Console.ReadLine();
            bool wasDeleted = _itemRepo.RemoveMenuItemFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("The Menu Item was Deleted");
            }
            else
            {
                Console.WriteLine("The Menu Item could not be Deleted.");
            }
        }

        private void SeedMenuList()
        {
            MenuItems burger = new MenuItems(1, "Classic Burger", "Classic Burger with toasted bun and full garden", "Bun, Beef Patty, Lettuce, tomato, pickle, onion", 6.5m);
            MenuItems cheeseBurger = new MenuItems(2, "Cheeseburger", "Cheeseburger with toasted bun and full garden", "Bun, Choice of cheese, Beef Patty, Lettuce, tomato, pickle, onion", 7.5m);
            MenuItems hotWings = new MenuItems(3, "Hot Wings", "House Wings served over a plate of fries", "Chicken, House Buffulo Sauce, French Fries", 10);

            _itemRepo.AddItemToList(burger);
            _itemRepo.AddItemToList(cheeseBurger);
            _itemRepo.AddItemToList(hotWings);
        }
    }
}
