
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace FruitApp.Domain
{
    public class Fruit 
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string origin { get; set; }
        public string largestCountry { get; set; }
        public decimal productionInBillions { get; set; }

        public Fruit( string id, string name, string origin, string largestCountry, decimal productionInBillions)
        {
            this.id = id;
            this.Name = name;
            this.origin = origin;
            this.largestCountry = largestCountry;
            this.productionInBillions = productionInBillions;
        }
    }
}