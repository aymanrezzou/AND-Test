using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AND_Test.Models;
using AND_Test.Services;
namespace AND_Test.Controllers
{
    [RoutePrefix("api/PhoneNumbers")]
    public class PhoneNoController : ApiController
    {
        IPhoneNoRepository _repository;
        public PhoneNoController()
        {
            _repository = new PhoneNoRepository(Global.PhoneNumbersList);
        }
        public PhoneNoController(IPhoneNoRepository repo)
        {
            _repository = repo;
        }   
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(_repository.GetAll().ToList<PhoneNumber>());
        }

        [HttpGet]
        [Route("CustomerID={id:int}")]
        public IHttpActionResult GetCustomerPhones(int id)
        {
            IList<PhoneNumber> res = _repository.GetAllForCustomer(id);
            if (res == null || res.Count == 0)
                return NotFound();
            return Ok(res.ToList<PhoneNumber>());
        }

        [HttpPut]
        [Route("{id:int}/Activate")]
        public IHttpActionResult ActivatePhoneNo(int id)
        {
            if (!_repository.MakeItActive(id))
                return Content(HttpStatusCode.NotFound, false);
            return Content(HttpStatusCode.Accepted, true);
        }



    }
}