using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Helper;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class DefaultController : ApiController
    {
        IEnumerable<Person> Users = UserFactory.GetSample();

        public IEnumerable<Person> Get()
        {
            return Users;
        }

        public Person Get(int id)
        {
            var result = Users.FirstOrDefault(x => x.UserID == id) ?? new Person();
            return result;
        }

        [HttpPost]
        public IHttpActionResult Post(Person user)
        {
            return Ok(Users.Where(x=>x.UserID == user.UserID));
        }
    }
}
