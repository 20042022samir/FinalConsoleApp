using ConssoleApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssoleApp.Core.Model
{
    public sealed class Product:Base
    {
        private static int _counter2 = 0;

        public double price { get; set; }

        public CategoryProduct categoryy { get; set; }

        public Product()
        {
            _counter2++;
            ID= _counter2;
        }
    }
}
