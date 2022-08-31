
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitApp.API
{
    public class UrlSingleton
    {

        private static string _url = null;
        //private static readonly string baseUrl = ConfigurationManager.AppSettings["APIUrl"];

        protected UrlSingleton(string url)
        {
            _url = url;
        }

        public static string url
        {
            get
            {
                if (_url == null)
                {
                    throw new Exception("Object not created");
                }
                return _url;
            }
        }

        public static void Create(string url)
        {
            if (_url == null)
            {
                new UrlSingleton(url);
            }
        }

    }

}