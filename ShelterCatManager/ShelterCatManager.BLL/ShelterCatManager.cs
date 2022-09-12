using ShelterCatManager.Models;
using ShelterCatManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterCatManager.BLL
{
    public class ShelterManager
    {
        ShelterCatRepository repo;

        public ShelterManager()
        {
            repo = new ShelterCatRepository();
        }
        public ShelterCat AddCat(ShelterCat cat)
        {
            bool isValid = validateCat(cat);
            if (!isValid)
            {
                return null;
            }

            return repo.CreateCat(cat);
        }

        public void DeleteCat(ShelterCat cat)
        {
            repo.DeleteCat(cat.CatID);
        }

        private bool validateCat(ShelterCat cat)
        {
            if (cat.CatID < 0 || String.IsNullOrEmpty(cat.CatName) || String.IsNullOrEmpty(cat.CatColor) || cat.CatAge < 0 )
            {
                return false;
            }

            return true;
        }
        public ShelterCat EditCat(ShelterCat cat)
        {
            //var catToEdit = repo.RetrieveCatByID(cat.CatID);
            return repo.EditCat(cat);
            
        }

        public ShelterCat[] GetCats()
        {
            return repo.RetrieveAllCats();
        }
        public ShelterCat GetCat(int catID)
        {
            return repo.RetrieveCatByID(catID);
        }
    }
}
