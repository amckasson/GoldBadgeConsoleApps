using _02_KomodoBadges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Console
{
    class ProgramUI
    {
        private KomodoBadgesRepository _badgeRepo = new KomodoBadgesRepository();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                    case "one":
                        AddBadge();
                        break;
                    case "2":
                    case "two":
                        UpdateBadge();
                        break;
                    case "3":
                    case "three":
                        ListAllBadges();
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
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddBadge()
        {
            KomodoBadges newBadge = new KomodoBadges();

            Console.WriteLine("Enter the badge ID number: ");
            string badgeIDAsString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeIDAsString);

            Console.WriteLine("Enter a door that Employee has access to : ");
            string doorAccessAsString = Console.ReadLine();
            newBadge.ListOfDoors = doorAccessAsString;
            Console.WriteLine("Any other doors (y/n)?");
            string ifYes = (Console.ReadLine());
            while (ifYes == "y")
            {
                Console.WriteLine("Enter another door: ");
                newBadge.ListOfDoors = Console.ReadLine();
                Console.WriteLine("Any other doors (y/n)?");
                string ifNo = Console.ReadLine();
                if (ifNo == "n")
                {
                    Console.Clear();
                    Menu();
                }
            }
            _badgeRepo.AddBadgeToDictionary(newBadge);
        }

        private void UpdateBadge()
        {
            //Dictionary<int, string> badgeInDictionary = _badgeRepo.GetBadges();
        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, KomodoBadges> badgeDictionary = _badgeRepo.GetBadges();
            foreach (KeyValuePair<int, KomodoBadges> entry in badgeDictionary)
            {
                Console.WriteLine(entry.Key + ":" + entry.Value);
            }


        }
    }
}
