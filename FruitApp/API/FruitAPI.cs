using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Flurl;
using Flurl.Http;

namespace AndroidApp.API
{
    public class FruitAPI
    {

        private readonly string _url =  UrlSingleton.url;

        public List<Fruit> Get<Fruit>(string endpoint)
        {
            return _url.AppendPathSegment(endpoint).GetJsonAsync<List<Fruit>>().Result;
        }



        public Fruit Get<Fruit>(string endpoint, string id)
        {
            return _url.AppendPathSegment(endpoint + "/" + id).GetJsonAsync<Fruit>().Result;
        }



        public bool Post<Fruit>(string endpoint, Fruit item)
        {
            var post = _url.AppendPathSegment(endpoint).PostJsonAsync(item).Result;
            return true;
        }




    }
}
