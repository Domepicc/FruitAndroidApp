
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace FruitApp.API
{
    public class FruitAPI
    {

        private readonly string _url =  UrlSingleton.url;


        //public List<Fruit> Get<Fruit>(string endpoint)
        //{
        //    return _url.AppendPathSegment(endpoint).GetJsonAsync<List<Fruit>>().Result;
        //}

        public Fruit Get<Fruit>(string endpoint)
        {
            return _url.AppendPathSegment(endpoint).GetJsonAsync<Fruit>().Result;
        }



        public Fruit Get<Fruit>(string endpoint, string id)
        {
            var x = _url.AppendPathSegment(endpoint + "/" + id);
            Task<Fruit> debug = _url.AppendPathSegment(endpoint + "/" + id).GetJsonAsync<Fruit>();
            return debug.Result;
        }



        public bool Post<Fruit>(string endpoint, Fruit item)
        {
            var post = _url.AppendPathSegment(endpoint).PostJsonAsync(item).Result;
            return true;
        }




    }
}
