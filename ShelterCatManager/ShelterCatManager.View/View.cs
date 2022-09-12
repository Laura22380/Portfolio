using ShelterCatManager.Models;
using ShelterCatManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterCatManager.View
{
    public class View
    {
        private UserIO userIO;
        private ShelterCatRepository repo;
        public View()
        {
            userIO = new UserIO();
            repo = new ShelterCatRepository();
        }
        public int ShowMenuAndGetUserChoice()
        {
            Console.WriteLine("\nEnter a choice from the menu below:");
            Console.WriteLine("1.Create New CatID");
            Console.WriteLine("2.List All Cats");
            Console.WriteLine("3.Find Cat by ID");
            Console.WriteLine("4.Edit Cat");
            Console.WriteLine("5.Remove Cat from System");
            Console.WriteLine("6.Exit Program");
            int userChoice = userIO.ReadInt("Enter your choice: ", 1, 6);
            return userChoice;
        }
        public ShelterCat GetNewCatInformation()
        {
            ShelterCat cat = new ShelterCat();
            cat.CatName = userIO.ReadString("\nEnter the cat's name: ");
            cat.CatColor = userIO.ReadString("Enter the cat's color: ");
            cat.CatAge = userIO.ReadInt("Enter the cat's age: ", 0, 30);
            cat.IsReadyForAdoption = userIO.ReadBool("Is the cat ready for adoption? Y or N");
            return cat;
        }
       
        public void DisplayCat(ShelterCat cat)
        {
            Console.WriteLine("\nCat ID: {0}", cat.CatID);
            Console.WriteLine("Cat's Name: {0}", cat.CatName);
            Console.WriteLine("Cat's Color: {0}", cat.CatColor);
            Console.WriteLine("Cat's Age: {0}", cat.CatAge);
            Console.WriteLine("Ready for Adoption: {0}", cat.IsReadyForAdoption);
        }
        
        public int GetCatID()
        {
            int catID = userIO.ReadInt("Enter the cat's ID: ", 0, 14);
            return catID;
        }

        public string ConfirmRemoval()
        {
            string confirm = userIO.ReadString("\nType 'Y' to confirm deletion. 'N' to exit: ");
            return confirm;
        }
        public void ShowActionSuccess(string actionName)
        {
            Console.WriteLine("\n{0} executed successfully.", actionName);
        }
        public void ShowActionFailure(string actionName)
        {
            Console.WriteLine("\n{0} failed to execute properly.", actionName);
        }
    }
}
