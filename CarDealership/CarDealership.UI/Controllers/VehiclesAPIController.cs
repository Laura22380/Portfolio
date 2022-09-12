using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    [RoutePrefix("api/vehicles")]
    public class VehiclesAPIController : ApiController
    {
        [Route("search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string minPrice, string maxPrice, int? minYear, int? maxYear, string makeModelYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters() { };

                if(minPrice != null && maxPrice != null)
                {
                    parameters = new VehicleSearchParameters()
                    {
                        MinPrice = Convert.ToDecimal(minPrice),
                        MaxPrice = Convert.ToDecimal(maxPrice),
                        MinYear = minYear,
                        MaxYear = maxYear,
                        MakeModelYear = makeModelYear
                    };
                }
                else if(minPrice != null && maxPrice ==null)
                {
                    parameters = new VehicleSearchParameters()
                    {
                        MinPrice = Convert.ToDecimal(minPrice),
                        MaxPrice = null,
                        MinYear = minYear,
                        MaxYear = maxYear,
                        MakeModelYear = makeModelYear
                    };
                }
                else if (minPrice == null && maxPrice != null)
                {
                    parameters = new VehicleSearchParameters()
                    {
                        MinPrice = null,
                        MaxPrice = Convert.ToDecimal(maxPrice),
                        MinYear = minYear,
                        MaxYear = maxYear,
                        MakeModelYear = makeModelYear
                    };
                }
                else
                {
                    parameters = new VehicleSearchParameters()
                    {
                        MinPrice = null,
                        MaxPrice = null,
                        MinYear = minYear,
                        MaxYear = maxYear,
                        MakeModelYear = makeModelYear
                    };
                }
                    
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
