using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{



    //POCO
    public class MenuItems
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string ListOfIngredients { get; set; }
        public decimal Price { get; set; }

        public MenuItems() { }

        public MenuItems(int mealNumber, string mealName, string mealDescription, string listOfIngredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }
    }
}
