using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Service
{
    public static class Helper
    {
        public static bool Check(string name)
        {
            bool status = true;
            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    status = false;
                    Console.WriteLine("you can not add any digit to the name");
                }
            }
            if (!char.IsUpper(name[0]))
            {
                status = false;
                Console.WriteLine("the frst letter must be upper");
            }
            if(string.IsNullOrWhiteSpace(name) )
            {
                status = false;
                Console.WriteLine("you must enter something to the name");
            }
            return status;
        }
    }
}
