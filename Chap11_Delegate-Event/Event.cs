using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chap11_Delegate_Event
{
    public class TimeInfoEventArgs: EventArgs
    {
        //
        public readonly int hour;
        public readonly int minute;
        public readonly int second;

        //
        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }                
    }

    public class Clock
    {
        // khai bao bien
        private int hour;
        private int minute;
        private int second;
        
        // Khai bao delegate ma cac subscriber phai thuc thi
        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInfo);

        // su kien ma chung ta dua ra
        public event SecondChangeHandler OnSecondChange;

        // thiet lap dong ho thuc hien, se phat ra moi su kien trong moi giay
        public void Run()
        {
            for (; ; )
            {
                Thread.Sleep(10);

                System.DateTime dt = DateTime.Now;

                if (dt.Second != second)
                {
                    TimeInfoEventArgs timeInfo = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);

                    if (OnSecondChange != null)
                    {
                        OnSecondChange(this, timeInfo);
                    }
                }
                // cap nhat trang thai
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
    }

    // Lop DisplayClock dang ky su kien cua clock
    // thuc thi xu ly su kien bang cach hien thoi gian hien hanh
    public class DisplayClock
    {
        public void Subscrible(Clock theClock)
        {
            theClock.OnSecondChange += new Clock.SecondChangeHandler(TimeHasChanged);
        }

        private void TimeHasChanged(object clock, TimeInfoEventArgs timeInfo)
        {
            Console.WriteLine("Current Time: {0}:{1}:{2}", timeInfo.hour.ToString(), timeInfo.minute.ToString(), timeInfo.second.ToString());
        }
    }

    // Lop dang ky su kien thu hai
    public class LogcurrentTime
    {
        public void Subscrible(Clock theClock)
        {
            theClock.OnSecondChange += new Clock.SecondChangeHandler(WriteLogEntry);
        }

        private void WriteLogEntry(object clock, TimeInfoEventArgs timeInfo)
        {
            Console.WriteLine("Logging to file: {0}:{1}:{2}", timeInfo.hour.ToString(), timeInfo.minute.ToString(), timeInfo.second.ToString());
        }
    }

    public class Event
    {
        public static void Main()
        {
            Console.WriteLine("Event...\n");
            // tao doi tuong clock
            Clock theClock = new Clock();
            // tao doi tuong DisplayClock dang ky su kien va xu ly su kien
            DisplayClock dc = new DisplayClock();
            dc.Subscrible(theClock);

            // tao doi tuong LogCurrent va dang ky va xu ly su kien
            LogcurrentTime lct = new LogcurrentTime();
            lct.Subscrible(theClock);

            // bat dau thuc hien vong lap va phat sinh su kien
            // trong moi giay dong ho
            theClock.Run();

            Console.ReadLine();

            while (true)
            {
                Console.ReadLine();
                Console.WriteLine("heheheh");

            }

            
        }
    }
}
