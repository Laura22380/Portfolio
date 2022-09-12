using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Data.Models;

namespace DvdLibrary.Data.Repositories.Interfaces
{
    public interface IDvdRepository
    {
        IEnumerable<Dvd> GetAll();
        IEnumerable<Dvd> GetAllByDirector(string rating);
        IEnumerable<Dvd> GetAllByRating(string rating);
        IEnumerable<Dvd> GetAllByTitle(string title);
        IEnumerable<Dvd> GetAllByYear(string year);
        Dvd GetById(int dvdId);
        void Add(Dvd dvd);
        void Edit(Dvd dvd);
        void Delete(int dvdId);
    }
}
