using System;
using System.Threading;

namespace Chap21_Thread
{
    class CreateThread
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread Start/Stop/Join Sample");
           
            Thread oThread = new Thread(new ThreadStart(Beta));

            // Start the thread
            oThread.Start();

            // Spin for a while waiting for the started thread to become alive
            while (!oThread.IsAlive) ;

            // Put the Main thread to sleep for 1 millisecond to allow oThread to do some work
            Thread.Sleep(2);

            // Request that oThread be stopped
            oThread.Abort();

            // Wait until oThread finishes. Join also has overloads that take a milisecond interval or a TimeSpan object.
            oThread.Join();

            Console.WriteLine();
            Console.WriteLine("Beta has finished.");

            try
            {
                Console.WriteLine("Try to restart the Beta thread");
                oThread.Start();
            }
            catch (ThreadStateException)
            {
                Console.WriteLine("ThreadStateException trying to restart Beta.");
                Console.WriteLine("Expected since aborted threads cannot be restarted.");
                
            }

            //Console.ReadKey();
        }

        public static void Beta()
        {
            while (true)
            {
                Console.WriteLine("Beta is running in its own thread.");
            }
        }

    }
}
