using ConssoleApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssoleApp.Core.Model
{
    public sealed class Restoran:Base
    {
        private static int _counter = 0;

        public CategoryRestoran Category { get; set; }

        public List<Product> products { get; set; }

        public Restoran()
        {
            _counter++;
            ID = _counter;
            products = new List<Product>();
        }
    }
}
