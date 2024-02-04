using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp
{
    internal class Device
    {
        public string model;
        public double modelPrice;
        public Device(string model, double modelPrice)
        {
            this.model = model;
            this.modelPrice = modelPrice;
        }
    }
}
