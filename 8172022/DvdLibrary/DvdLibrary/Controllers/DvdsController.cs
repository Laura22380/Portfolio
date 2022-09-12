using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdLibrary.Data.Factories;
using System.Web.Http.Cors;
using DvdLibrary.Data.Repositories;
using DvdLibrary.Data.Models;
using DvdLibrary.Models;

namespace DvdLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdsController : ApiController
    {
        private DvdRepositoryFactory _factory;

        public DvdsController()
        {
            _factory = new DvdRepositoryFactory();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            var repo = _factory.GetRepository();

            var x = repo.GetById(id);

            return "good job bud";
        }

        [Route("api/dvds/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            var repo = _factory.GetRepository();
            List<Dvd> dvd = repo.GetAll().ToList();

            if (dvd.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(repo.GetAll());
            }
        }

        [Route("api/dvds/get/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int dvdId)
        {
            var repo = _factory.GetRepository();
            Dvd dvd = repo.GetById(dvdId);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddDvdRequest request)
        {
            var repo = _factory.GetRepository();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Dvd dvd = new Dvd()
            {
                Title = request.Title,
                ReleaseYear = request.ReleaseYear,
                Director = request.Director,
                Rating = request.Rating
            };

            repo.Add(dvd);
            return Created($"dvds/get/{dvd.DvdId}", dvd);
        }

        [Route("dvds/update")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(AddDvdRequest request)
        {
            var repo = _factory.GetRepository();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Dvd dvd = repo.GetById(request.DvdId);
            if (dvd == null)
            {
                return NotFound();
            }

            dvd.Title = request.Title;
            dvd.ReleaseYear = request.ReleaseYear;
            dvd.Director = request.Director;
            dvd.Rating = request.Rating;

            repo.Edit(dvd);
            return Ok(dvd);
        }

        [Route("dvds/delete/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {
            var repo = _factory.GetRepository();
            Dvd dvd = repo.GetById(dvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            repo.Delete(dvdId);
            return Ok();
        }

        [Route("dvds/get/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByTitle(string title)
        {
            var repo = _factory.GetRepository();
            List<Dvd> dvd = repo.GetAllByTitle(title).ToList();

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(repo.GetAllByTitle(title));
            }
        }

        [Route("dvds/get/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByDirector(string director)
        {
            var repo = _factory.GetRepository();
            IEnumerable<Dvd> dvd = repo.GetAllByDirector(director);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(repo.GetAllByDirector(director));
            }
        }

        [Route("dvds/get/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByRating(string rating)
        {
            var repo = _factory.GetRepository();
            IEnumerable<Dvd> dvd = repo.GetAllByRating(rating);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(repo.GetAllByRating(rating));
            }
        }

        [Route("dvds/get/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByYear(string releaseYear)
        {
            var repo = _factory.GetRepository();
            IEnumerable<Dvd> dvd = repo.GetAllByYear(releaseYear);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(repo.GetAllByYear(releaseYear));
            }
        }
        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}