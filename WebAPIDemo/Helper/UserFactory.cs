using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIDemo.Models;

namespace WebAPIDemo.Helper
{
    public static class UserFactory
    {
        static List<Person> persons = new List<Person>
        {
            new Person { UserID=1, UserName="RECO", Age=40},
            new Person { UserID=2, UserName="Gian", Age=41},
            new Person { UserID=3, UserName="Andy", Age=25},
            new Person { UserID=4, UserName="Barry", Age=39}
        };

        public static List<Person> GetSample() => persons;
    }
}