using CarDealership.Data.ADO;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class ContactsAPIController : ApiController
    {
        [Route("api/home/contact/add/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContact(Contacts contact)
        {
            var repo = new ContactsRepositoryADO();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                repo.AddContact(contact);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
