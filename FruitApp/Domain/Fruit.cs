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

namespace FruitApp.Domain
{
    public class Fruit 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string LargestCountry { get; set; }
        public decimal ProductionInBillions { get; set; }

        public Fruit()
        {

        }
        public Fruit( string id, string name, string origin, string largestCountry, decimal productionInBillions)
        {
            this.Id = id;
            this.Name = name;
            this.Origin = origin;
            this.LargestCountry = largestCountry;
            this.ProductionInBillions = productionInBillions;
        }
    }
}