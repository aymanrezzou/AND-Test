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
      
     
    }
}