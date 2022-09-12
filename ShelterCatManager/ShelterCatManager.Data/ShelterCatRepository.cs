using ShelterCatManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterCatManager.Data
{
    public class ShelterCatRepository
    {
        ShelterCat[] cats;
        public ShelterCatRepository()
        {
            cats = new ShelterCat[15];

            ShelterCat cat1 = new ShelterCat();
            cat1.CatID = 0;
            cat1.CatName = "Ashes";
            cat1.CatColor = "Grey";
            cat1.CatAge = 12;
            cat1.IsReadyForAdoption = false;
            cats[0] = cat1;

            ShelterCat cat2 = new ShelterCat();
            cat2.CatID = 1;
            cat2.CatName = "Zoe";
            cat2.CatColor = "Grey Tiger";
            cat2.CatAge = 1;
            cat2.IsReadyForAdoption = true;
            cats[1] = cat2;
        }
        public ShelterCat CreateCat(ShelterCat cat)
        {
            for (int i = 0; i < cats.Length; i++)
            {
                if(cats[i] == null)
                {
                    cat.CatID = i;
                    cats[i] = cat;
                    return cat;
                }
            }
            return cat;
        }
        public ShelterCat[] RetrieveAllCats()
        {
            return cats;
        }
        public ShelterCat RetrieveCatByID(int catID)
        {
            return cats[catID];
        }
        public void DeleteCat(int catID)
        {
            cats[catID] = null;         
        }
        public ShelterCat EditCat(ShelterCat cat)
        {
            cats[cat.CatID] = cat;
            return cat;
        }
    }
}
