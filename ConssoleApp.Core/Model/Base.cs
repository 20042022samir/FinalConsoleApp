using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssoleApp.Core.Model
{
    public abstract class Base
    {
        public string name { get; set; }

        public int ID { get; set; }

        public DateTime CreatedTme { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
