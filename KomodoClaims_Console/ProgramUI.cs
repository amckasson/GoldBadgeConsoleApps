using KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    class ProgramUI
    {
        private KomodoClaimsRepository _claimRepo = new KomodoClaimsRepository();
        public void Run()
        {
            SeedClaimQueue();
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
            Console.Clear();
            Queue<KomodoClaims> queueOfClaims = _claimRepo.GetClaimsQueue();

            foreach(KomodoClaims claim in queueOfClaims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
               $"Claim Type: {claim.TypeOfClaim}\n" +
               $"Claim Description: {claim.Description}\n" +
               $"Claim Amount: {claim.ClaimAmount}\n" +
               $"Date of Incedent: {claim.DateOfIncident.ToShortDateString()}\n" +
               $"Date of Claim: {claim.DateOfClaim.ToShortDateString()}\n" +
               $"Is Valid: {claim.IsValid}\n\n");
            }
        }
        private void DequeueClaim()
        {

        }
        private void EnqueueClaim()
        {
            KomodoClaims newClaim = new KomodoClaims();

            Console.WriteLine("Enter the claim ID number.");
            string CliamIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(CliamIDAsString);

            Console.WriteLine("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Enter a description of the claim.");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount for the claim.");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(claimAmountAsString);

            //Not sure if next two methods will work below

            //Console.WriteLine("Enter the date of the incident MM/DD/YYYY");
            //DateTime incidentDate = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the date of the claim MM/DD/YYYY");
            //DateTime claimDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the incident. MM/DD/YYYY");
            DateTime incidentDate = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfIncident = incidentDate;

            Console.WriteLine("Enter the date of the claim. MM/DD/YYYY");
            DateTime claimDate = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfClaim = claimDate;

            //Not sure if two methods above will work

            //Console.WriteLine("Is this claim valid? Was it made within 30 days of the incident? (y/n)");
            //string isValidAsString = Console.ReadLine().ToLower();

            //if (isValidAsString == "y")
            //{
            //    newClaim.IsValid = true;
            //}
            //else
            //{
            //    newClaim.IsValid = false;
            //}

            TimeSpan isItValid = claimDate - incidentDate;
            double totalDays = isItValid.TotalDays;
            if (totalDays <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimRepo.AddClaimToQueue(newClaim);
        }

        private void SeedClaimQueue()
        {
            KomodoClaims claimOne = new KomodoClaims(1, ClaimType.Car, "Car Crash", 5000m, DateTime.Today, DateTime.Now, false);
            
            KomodoClaims claimTwo = new KomodoClaims(2, ClaimType.Home, "Fire", 50000m, DateTime.Today, DateTime.Now, false);
            
            KomodoClaims claimThree = new KomodoClaims(3, ClaimType.Theft, "Car stolen", 5000m, DateTime.Today, DateTime.Now, false);

            _claimRepo.AddClaimToQueue(claimOne);
            _claimRepo.AddClaimToQueue(claimTwo);
            _claimRepo.AddClaimToQueue(claimThree);
        }
    }
}
