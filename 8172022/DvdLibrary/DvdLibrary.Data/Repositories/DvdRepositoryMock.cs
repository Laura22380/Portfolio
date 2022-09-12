using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Data.Repositories.Interfaces;
using DvdLibrary.Data.Models;

namespace DvdLibrary.Data.Repositories
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd
            {DvdId=1, Title="Ghostbusters", ReleaseYear=1984, Director="Ivan Reitman", Rating="PG"},
            new Dvd
            {DvdId=2, Title="Finding Nemo", ReleaseYear=2003, Director="Andrew Stanton", Rating="G" },
            new Dvd
            {DvdId=3, Title="27 Dresses", ReleaseYear=2008, Director="Anne Fletcher", Rating="PG-13" }
        };

        public IEnumerable<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd GetById(int dvdId)
        {
            return _dvds.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public IEnumerable<Dvd> GetAllByTitle(string title)
        {
            return _dvds.TakeWhile(d => d.Title.Contains(title));
        }

        public IEnumerable<Dvd> GetAllByYear(string releaseYear)
        {
            return _dvds.TakeWhile(d => d.ReleaseYear.Equals(releaseYear));
        }

        public IEnumerable<Dvd> GetAllByDirector(string director)
        {
            return _dvds.TakeWhile(d => d.Director.Contains(director));
        }

        public IEnumerable<Dvd> GetAllByRating(string rating)
        {
            return _dvds.TakeWhile(d => d.Rating.Equals(rating));
        }

        public void Add(Dvd dvd)
        {

            dvd.DvdId = _dvds.Max(d => d.DvdId) + 1;
            _dvds.Add(dvd);
        }

        public void Edit(Dvd dvd)
        {
            var found = _dvds.FirstOrDefault(d => d.DvdId == dvd.DvdId);
            if (found != null)
            {
                found = dvd;
            }

            //_dvds.RemoveAll(d=>d.DvdId == dvd.DvdId);
            //_dvds.Add(dvd);
        }

        public void Delete(int dvdId)
        {
            _dvds.RemoveAll(d => d.DvdId == dvdId);
        }
    }
}
