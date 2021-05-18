using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
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
                    "1. See all claims.\n" +
                    "2. Take care of next claim.\n" +
                    "3. Enter new claim.\n" +
                    "4. Exit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                    case "one":
                        DisplayAllClaims();
                        break;
                    case "2":
                    case "two":
                        DequeueClaim();
                        break;
                    case "3":
                    case "three":
                        EnqueueClaim();
                        break;
                    case "4":
                    case "four":
                        Console.WriteLine("Have a great day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayAllClaims()
        {

        }
        private void DequeueClaim()
        {

        }
        private void EnqueueClaim()
        {

        }
    }
}
