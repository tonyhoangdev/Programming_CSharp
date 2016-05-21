using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap9_Array_Index_Collection
{
    public class Program
    {
        public static void PrintArray(object[] theArray)
        {
            foreach (object obj in theArray)
            {
                Console.WriteLine("Value: {0}", obj);
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            string[] myArray = 
            {
                "Who", "is", "Kitty", "Mun"
            };
            PrintArray(myArray);
            Array.Reverse(myArray);
            PrintArray(myArray);

            string[] myOtherArray = 
            {
                "Chung", "toi", "la", "nhung", "nguoi",
                "lap", "trinh", "may", "tinh"
            };
            PrintArray(myOtherArray);
            Array.Sort(myOtherArray);
            PrintArray(myOtherArray);

            Console.ReadKey();
        }

    }
}
