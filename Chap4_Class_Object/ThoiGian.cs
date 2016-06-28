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
            nam = dt.Year;
            thang = dt.Month;
            ngay = dt.Day;
            gio = dt.Hour;
            phut = dt.Minute;
            giay = dt.Second; // Gan cho bien thanh vien giay
        }

        // Ham khoi dung voi bien thanh vien khoi tao san
        public ThoiGian(int year, int month, int day, int hour, int minute)
        {
            nam = year;
            thang = month;
            ngay = day;
            gio = hour;
            phut = minute;            
        }

        // Ham khoi dung sao chep
        public ThoiGian(ThoiGian tg)
        {
            nam = tg.Nam;
            thang = tg.thang;
            ngay = tg.ngay;
            gio = tg.gio;
            phut = tg.phut;
            giay = tg.giay;
        }

        // Ham khoi dung tinh, duoc goi truoc tien
        // Huu dung khi chung ta can cai dat mot so cong viec ma khong the thuc hien duoc thong qua chuc nang khoi dung
        // va cong viec cai dat nay chi duoc thuc hien duy nhat mot lan.
        // Trong vi du don gian nay, khong can dung bo khoi dung tinh, ma dung khoi tao bien thanh vien la duoc. 
        static ThoiGian()
        {
            ten = "Thoi Gian";
        }

        // Phuong thuc
        public void ThoiGianHienHanh()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("\nTen: {0}", ten);
            Console.WriteLine("Hien tai:\t{0}/{1}/{2} {3}:{4}:{5}", now.Day, now.Month, now.Year, now.Hour, now.Minute, now.Second);
            Console.WriteLine("Thoi gian:\t{0}/{1}/{2} {3}:{4}:{5}", ngay, thang, Nam, gio, phut, giay);
        }

        // get time dung tham chieu ref
        public void GetTime(ref int gio, ref int phut, ref int giay)
        {
            gio = this.gio;
            phut = this.phut;
            giay = this.giay;
        }

        // get date dung tham chieu out, khong can khoi tao gia tri ban dau
        public void GetDay(out int nam, out int thang, out int ngay)
        {
            nam = this.nam;
            thang = this.thang;
            ngay = this.ngay;
        }

        // Cac bien thanh vien
        private int nam;
        private int thang;
        private int ngay;
        private int gio;
        private int phut;
        private int giay = 30; // Bien thanh vien duoc khoi tao
        public static readonly string ten = "Thoi Gian 1"; // Bien thanh vien tinh duoc truy cap boi ham khoi dung Tinh

        // Thuoc tinh
        public int Nam
        {
            get
            {
                return nam;
            }

            set
            {
                nam = value;
            }
        }
    }
}
