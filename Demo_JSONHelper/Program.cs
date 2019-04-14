using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSF.JsonHandler;

namespace Demo_JSONHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = new JsonRequest();
            var url = "http://localhost:6248";
            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();

            //一般的執行方式(需自行 Parser Json)
            sw1.Start();
            Console.WriteLine("Demo 01: 同步的執行方式(需自行 Parser Json)\n執行結果：");
            Console.WriteLine("===================================================");
            var result01 = json.Execute($"{url}/API/default");

            Console.WriteLine($"{result01}\n");
            sw1.Stop();
            Console.WriteLine($"共花費:{sw1.ElapsedMilliseconds}");

            //非同步的執行方式(需自行 Parser Json)
            sw2.Start();
            Console.WriteLine("\nDemo 02: 非同步的執行方式(需自行 Parser Json)\n執行結果：");
            Console.WriteLine("=======================================================");
            var result02 = json.ExecuteAsync($"{url}/API/default").Result;

            Console.WriteLine($"{result02}\n");
            sw2.Stop();

            //非同步的執行方式(無需自行 Parser Json)
            sw3.Start();
            Console.WriteLine("\nDemo 03: 非同步的執行方式(需自行 Parser Json)\n執行結果：(waiting....)");
            Console.WriteLine("====================================================================");
            var result03 = (IEnumerable<Person>)json.ExecuteAsync<IEnumerable<Person>>($"{url}/API/default").Result;
            foreach (var item in result03)
            {
                Console.WriteLine($"UserID:{item.UserID}\tUserName:{item.UserName}\tAge:{item.Age}");
            }
            Console.WriteLine("End");
            sw3.Stop();
            Console.WriteLine($"\nDemo1共花費:{sw1.ElapsedMilliseconds}\nDemo2共花費:{sw2.ElapsedMilliseconds}\nDemo3共花費:{sw3.ElapsedMilliseconds}");

            //非同步的POST執行方式(需自行 Parser Json)
            var QueryModel1 = new Person() { UserID = 1, UserName = "RECO", Age = 40 };
            Console.WriteLine("\nDemo 4: 非同步的POST執行方式(需自行 Parser Json)\n執行結果：");
            Console.WriteLine("=======================================================");
            var result04 = json.ExecuteAsync($"{url}/API/default/", QueryModel1, "POST").Result;

            Console.WriteLine($"{result04}\n");

            //非同步的POST執行方式(無需自行 Parser Json)
            var QueryModel2 = new Person() { UserID = 1, UserName = "RECO", Age = 40 };
            Console.WriteLine("\nDemo 5: 非同步的POST執行方式(無需自行 Parser Json)\n執行結果：");
            Console.WriteLine("=======================================================");
            var result05 = (IEnumerable<Person>)json.ExecuteAsync<IEnumerable<Person>>($"{url}/API/default/", QueryModel2, "POST").Result;
            foreach (var item in result05)
            {
                Console.WriteLine($"UserID:{item.UserID}\tUserName:{item.UserName}\tAge:{item.Age}");
            }

            Console.ReadLine();

        }

    }

    public class Person
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}
