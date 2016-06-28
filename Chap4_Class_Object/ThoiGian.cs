using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap4_Class_Object
{
    class ThoiGian
    {
        // Ham khoi dung
        public ThoiGian(DateTime dt)
        {
            Nam = dt.Year;
            Thang = dt.Month;
            Ngay = dt.Day;
            Gio = dt.Hour;
            Phut = dt.Minute;
            Giay = dt.Second; // Gan cho bien thanh vien Giay
        }

        // Ham khoi dung voi bien thanh vien khoi tao san
        public ThoiGian(int year, int month, int day, int hour, int minute)
        {
            Nam = year;
            Thang = month;
            Ngay = day;
            Gio = hour;
            Phut = minute;            
        }

        // Ham khoi dung sao chep
        public ThoiGian(ThoiGian tg)
        {
            Nam = tg.Nam;
            Thang = tg.Thang;
            Ngay = tg.Ngay;
            Gio = tg.Gio;
            Phut = tg.Phut;
            Giay = tg.Giay;
        }

        // Phuong thuc
        public void ThoiGianHienHanh()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("\nHien tai:\t{0}/{1}/{2} {3}:{4}:{5}", now.Day, now.Month, now.Year, now.Hour, now.Minute, now.Second);
            Console.WriteLine("Thoi gian:\t{0}/{1}/{2} {3}:{4}:{5}", Ngay, Thang, Nam, Gio, Phut, Giay);
        }

        // Cac bien thanh vien
        private int Nam;
        private int Thang;
        private int Ngay;
        private int Gio;
        private int Phut;
        private int Giay = 30; // Bien thanh vien duoc khoi tao
    }
}
