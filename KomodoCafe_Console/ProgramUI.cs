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
        public void Run()
        {
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
        }

        private void DisplayAllMenuItems()
        {

        }

        private void DisplayItemByName()
        {

        }

        private void UpdateExistingItem()
        {

        }

        private void DeleteExistingItem()
        {

        }
    }
}
