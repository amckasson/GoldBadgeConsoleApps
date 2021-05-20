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
            SeedData();
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
            newBadge.ListOfDoors = new List<string>();

            Console.WriteLine("Enter the badge ID number: ");
            string badgeIDAsString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeIDAsString);

            Console.WriteLine("Enter a door that Employee has access to : ");
            newBadge.ListOfDoors.Add(Console.ReadLine());
            Console.WriteLine("Any other doors (y/n)?");
            string ifYes = (Console.ReadLine());
            while (ifYes == "y")
            {
                Console.WriteLine("Enter another door: ");
                newBadge.ListOfDoors.Add(Console.ReadLine());
                Console.WriteLine("Any other doors (y/n)?");
                string ifNo = Console.ReadLine();
                if (ifNo == "n")
                {
                    Console.Clear();
                    Menu();
                }
            }

            bool wasAddedCorrectly = _badgeRepo.AddBadgeToDictionary(newBadge.BadgeID, newBadge.ListOfDoors);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("Your badge was added correctly!!");
            }
            else
            {
                Console.WriteLine("Failed to add your badge.");
            }
        }

        private void UpdateBadge()
        {
            Console.Clear();
            List<string> doorAccess = new List<string>();
            Dictionary<int, List<string>> badgeRepo = _badgeRepo.GetBadges();
            Console.WriteLine("Enter the badge ID number that you want to update: ");
            int badgeToUpdate = Convert.ToInt32(Console.ReadLine());

            if (badgeRepo.ContainsKey(badgeToUpdate))
            {
                Console.WriteLine($"Would you like to add or a remove a door to {badgeToUpdate}?\n" +
                    "1. Add Door\n" +
                    "2. Remove Door");
                int input = Convert.ToInt32(Console.ReadLine());
                bool isRunning;
                if (input == 1)
                {
                    isRunning = true;
                    while (isRunning)
                    {
                        Console.WriteLine("Add a door name: ");
                        string newDoor = Console.ReadLine();
                        doorAccess.Add(newDoor);
                        badgeRepo.Add(badgeToUpdate, new List<string> { newDoor });
                        Console.Write("Add new door?");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "n" || userInput.ToLower() == "no")
                        {
                            isRunning = false;
                        }


                    }
                }


            }

            switch (input)
            {
                case 1:
                    _badgeRepo.AddDoorToBadge();
                    break;

                default:
                    break;
            }

            if (input == "Add Door")
            {
                Console.WriteLine($"What door would you like to add to {badgeToUpdate}: ");
                //int doorToAdd = Console.ReadLine()

            }



        }


        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetBadges();
            foreach (KeyValuePair<int, List<string>> entry in badgeDictionary)
            {
                Console.WriteLine(entry.Key + ":");
                foreach (string room in entry.Value)
                {
                    Console.Write($" {room}\n");
                }
            }


        }

        private void SeedData()
        {
            _badgeRepo.AddBadgeToDictionary(227, new List<string> { "23", "24", "25" });
        }

    }
}
