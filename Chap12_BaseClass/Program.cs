using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Chap12_BaseClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer myTimer = new Timer();

            // khai bao ham xu ly
            myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            // khoang thoi gian delay
            myTimer.Interval = 1000;
            myTimer.Start();

            while(Console.Read() != 'q')
            {
                ;
            }

            Console.ReadLine();
        }

        private static void DisplayTimeEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("\n{0}", DateTime.Now);
        }
    }
}
