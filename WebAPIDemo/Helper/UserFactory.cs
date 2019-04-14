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

        static List<Person> persons2 = new List<Person>();


        public static IEnumerable<Person> GetSample()
        {
            //var randomchar = "0123456789abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZ";
            //var rand = new Random();

            //for (int i = 1; i <= 50000; i++)
            //{
            //    yield return new Person()
            //    {
            //        UserID = i,
            //        UserName = new string(Enumerable.Repeat(randomchar, 10).Select(x => x[rand.Next(x.Length)]).ToArray()),
            //        Age = rand.Next(10, 99)
            //    };
            //}
            return persons;
        }
    }
}