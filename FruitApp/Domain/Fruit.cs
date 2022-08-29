using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace AndroidApp.Domain
{
    public class Fruit 
    {
        public string IdFruit { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string LargestCountry { get; set; }
        public int ProductionInBillions { get; set; }

    }
}