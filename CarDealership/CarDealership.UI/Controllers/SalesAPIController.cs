using CarDealership.Data.ADO;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class SalesAPIController : ApiController
    {
        [Route("api/sales/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(DateTime? fromDate, DateTime? toDate, string UserName)
        {
            var repo = new SalesRepositoryADO();

            try
            {
                if (fromDate == null)
                {
                    fromDate = new DateTime(2019,05,01,9,15,0);
                }

                if (toDate == null)
                {
                    toDate = DateTime.Today;
                }

                var parameters = new SalesSearchParameters()
                {
                    FromDate = (DateTime)fromDate,
                    ToDate = (DateTime)toDate,
                    UserName = UserName
                };

                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
