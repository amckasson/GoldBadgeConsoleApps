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
            KomodoBadges badges = new KomodoBadges();
            badges.ListOfDoors = new List<string>();
            Console.Clear();
            Console.WriteLine("Enter the badge ID number that you want to update: ");
            badges.BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you want to add a door or remove a door?\n" +
                "1. add\n" +
                "2. remove");
            string input = Console.ReadLine();
            if (input == "add")
            {
                Console.WriteLine("Whats the door that you would like to add?");
                string door = Console.ReadLine();
                _badgeRepo.AddDoorToBadge(badges.BadgeID, door);
            }
            bool addedBadge = _badgeRepo.AddBadgeToDictionary(badges.BadgeID, badges.ListOfDoors);

            if (addedBadge == true)
            {
                Console.WriteLine("Door added successfully.");
            }
            else
            {
                Console.WriteLine("Door could not be added.");
            }
            if (input == "remove")
            {
                Console.WriteLine("Whats the door that you would like to remove?");
                string doorRemove = Console.ReadLine();
                _badgeRepo.RemoveDoorFromBadge(badges.BadgeID, doorRemove);
            }
            //bool removedBadge = _badgeRepo.RemoveDoorFromBadge(badges.BadgeID, badges.ListOfDoors);

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
