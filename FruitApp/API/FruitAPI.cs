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
using System.Threading.Tasks;

namespace FruitApp.API
{
    public class FruitAPI
    {
        private readonly string _url =  UrlSingleton.url;

        public List<Fruit> Get<Fruit>()
        {
            return _url.GetJsonAsync<List<Fruit>>().Result;
        }

        public Fruit Get<Fruit>( string id)
        {
            return _url.AppendPathSegment(id).GetJsonAsync<Fruit>().Result; 
        }


        public bool Post<Fruit>( Fruit item)
        {
            var post = _url.PostJsonAsync(item).Result;
            return true;
        }

        public bool Post<FruitForPost>(FruitForPost item, string id)
        {
            var post = _url.AppendPathSegment(id).PatchJsonAsync(item).Result;
            return true;
        }




    }
}
