using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap4_Class_Object
{
    class Cat
    {
        // Ham khoi dung
        public Cat()
        {
            instance++;
        }

        // 
        public static void HowManyCats()
        {
            Console.WriteLine("{0} cats", instance);
        }

        private static int instance = 0; // bien thanh vien tinh

    }
}
