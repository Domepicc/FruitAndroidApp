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
using static Android.Provider.CalendarContract;

namespace AndroidApp.API
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