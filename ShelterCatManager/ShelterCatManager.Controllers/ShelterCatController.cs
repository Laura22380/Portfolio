using ShelterCatManager.Data;
using ShelterCatManager.Models;
using ShelterCatManager.View;
using ShelterCatManager.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterCatManager.Controllers
{
    public class ShelterCatController
    {
        private View.View userInterface;
        private ShelterCatRepository repo;
        private ShelterManager catManager;
        
        public ShelterCatController()
        {
            userInterface = new View.View();
            //repo = new ShelterCatRepository();
            catManager = new ShelterManager();
        }

        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                int menuChoice = userInterface.ShowMenuAndGetUserChoice();
                switch (menuChoice)
                {
                    case 1:
                        AddCat();
                        break;
                    case 2:
                        ShowAllCats();
                        break;
                    case 3:
                        SearchCats();
                        break;
                    case 4:
                        EditCat();
                        break;
                    case 5:
                        DeleteCat();
                        break;
                    case 6:
                        keepRunning = false;
                        break;
                }
            }
        }
        private void AddCat()
        {
            ShelterCat newCat = userInterface.GetNewCatInformation();
            ShelterCat addedCat = catManager.AddCat(newCat);
            if (addedCat == null)
            {
                userInterface.ShowActionFailure("Create Cat");             
            }

            userInterface.DisplayCat(addedCat);
            userInterface.ShowActionSuccess("Create Cat");
        }
        private void ShowAllCats()
        {
            ShelterCat[] cats = catManager.GetCats();
            
            for (int i = 0; i < cats.Length; i++)
            {
                ShelterCat currentCat = cats[i];
                if (currentCat != null)
                {
                    userInterface.DisplayCat(cats[i]);
                }             
            }
        }
        private void SearchCats()
        {
            int catID = userInterface.GetCatID();
            ShelterCat searchedCat = catManager.GetCat(catID);
            if (searchedCat != null)
            {
                userInterface.DisplayCat(searchedCat);
                userInterface.ShowActionSuccess("Find Cat by ID");
            }
            else
            {
                userInterface.ShowActionFailure("Find Cat by ID");
            }
        }
        private void DeleteCat()
        {
            int catID = userInterface.GetCatID();
            ShelterCat cat = catManager.GetCat(catID);
            string confirm = userInterface.ConfirmRemoval().ToUpper();
            if (confirm != "Y")
            {

                userInterface.ShowActionFailure("Remove Cat");
            }
            else
            {
                catManager.DeleteCat(cat);
                userInterface.ShowActionSuccess("Remove Cat");
            }
            

        }
        private void EditCat()
        {
            int catID = userInterface.GetCatID();
            //ShelterCat cat = repo.RetrieveCatByID(catID);
           
            //ShelterCat catToModify = BLL.GetCatByID()
            ShelterCat catToModify = userInterface.GetNewCatInformation();
            catToModify.CatID = catID;
            ShelterCat updatedCat = catManager.EditCat(catToModify);
            if (updatedCat != null)
            {
                userInterface.DisplayCat(updatedCat);
                userInterface.ShowActionSuccess("Edit cat");
            }
            else
            {
                userInterface.ShowActionFailure("Edit cat");
            }
        }
        

    }
}
