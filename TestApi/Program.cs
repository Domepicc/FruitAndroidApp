using FruitApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitApp.API;
using FruitApp.Domain;
using static System.Net.WebRequestMethods;

namespace FruitApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string url = @"https://postmanmaster.herokuapp.com/fruit/";
            UrlSingleton.Create(url);

            FruitAPI api = new FruitAPI();

            var result= api.Get<Fruit>("", "1");

            Console.WriteLine(result);




        }
    }
}
