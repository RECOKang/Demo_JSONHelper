using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIDemo.Helper;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class DefaultController : ApiController
    {
        List<Person> Users = UserFactory.GetSample();

        public List<Person> Get()
        {
            return Users;
        }

        public Person Get(int id)
        {
            var result = Users.FirstOrDefault(x => x.UserID == id)?? new Person();
            return result;
        }
    }
}
