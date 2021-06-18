using KIDTMA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDTMA.UI
{
    public class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamsRepo _devTeamsRepo = new DevTeamsRepo();

        public void Run()
        {
            SeedDeveloperList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Member:\n" +
                    "2. View All Members:\n" +
                    "3. View Members By Team Name:\n" +
                    "4. Update Existing Member:\n" +
                    "5. Delete Existing Member:\n" +
                    "6. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMember();
                        break;
                    case "2":
                        DisplayAllMembers();
                        break;
                    case "3":
                        DisplayMembersByTeamName();
                        break;
                    case "4":
                        UpdateExistingMember();
                        break;
                    case "5":
                        DeleteExistingMember();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press a new key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewMember()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter name of new member:");
            newDeveloper.MemberName = Console.ReadLine();

            Console.WriteLine("Enter new Identification Number:");
            string idAsString = Console.ReadLine();
            newDeveloper.IdentificationNumber = int.Parse(idAsString);

            Console.WriteLine("Do they have access to Pluralsight? (y/n)");
            string pluralsightString = Console.ReadLine().ToLower();

            if (pluralsightString == "y")
            {
                newDeveloper.AccessToPluralsight = true;
            }
            else
            {
                newDeveloper.AccessToPluralsight = false;
            }

            _developerRepo.AddDeveloperToList(newDeveloper);
        }

        private void DisplayAllMembers()
        {
            Console.Clear();

            List<Developer> listOfDeveloper = _developerRepo.GetDeveloperList();

            foreach (Developer developer in listOfDeveloper)
            {
                Console.WriteLine($"Member name: {developer.MemberName}\n" +
                    $"Identification Number: {developer.IdentificationNumber}\n" +
                    $"Access to Pluralsight? {developer.AccessToPluralsight}");
            }
        }

        private void DisplayMembersByTeamName()
        {
            Console.Clear();

            Console.WriteLine("Enter Team Name to Display Members:");

            string teamName = Console.ReadLine();

            DevTeams devTeams = _devTeamsRepo.GetDevTeamsByTeamName(teamName);

            if (devTeams != null)
            {
                Console.WriteLine($"Team Name: {devTeams.TeamName}\n" +
                    $"Team Members: {devTeams.TeamMembers}\n" +
                    $"Team Identification Number: {devTeams.TeamIdentificationNumber}");
            }
            else
            {
                Console.WriteLine("No team by that name.");
            }
        }

        private void UpdateExistingMember()
        {
            DisplayAllMembers();

            Console.WriteLine("Enter the member you'd like to update:");

            string oldDeveloper = Console.ReadLine();

            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter name of new member:");
            newDeveloper.MemberName = Console.ReadLine();

            Console.WriteLine("Enter new Identification Number:");
            string idAsString = Console.ReadLine();
            newDeveloper.IdentificationNumber = int.Parse(idAsString);

            Console.WriteLine("Do they have access to Pluralsight? (y/n)");
            string pluralsightString = Console.ReadLine().ToLower();

            if (pluralsightString == "y")
            {
                newDeveloper.AccessToPluralsight = true;
            }
            else
            {
                newDeveloper.AccessToPluralsight = false;
            }
            
            bool wasUpdated = _developerRepo.UpdateExistingDeveloper(oldDeveloper, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update developer.");
            }
        }

        private void DeleteExistingMember()
        {
            DisplayAllMembers();

            Console.WriteLine("\nEnter the member you'd like to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The member was succesfully deleted.");
            }
            else
            {
                Console.WriteLine("The member could not be deleted.");
            }
        }

        private void SeedDeveloperList()
        {
            Developer erinMckinney = new Developer("Erin McKinney", 123456, true);
            Developer harryPotter = new Developer("Harry Potter", 789101, true);
            Developer dracoMalfoy = new Developer("Draco Malfoy", 112131, false);

            _developerRepo.AddDeveloperToList(erinMckinney);
            _developerRepo.AddDeveloperToList(harryPotter);
            _developerRepo.AddDeveloperToList(dracoMalfoy);
        }
    }
}
