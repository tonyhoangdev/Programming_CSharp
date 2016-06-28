using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap4_Class_Object
{
    class DuongTron
    {
        // Bien thanh vien
        private int banKinh = 0;
        private Point tam;

        // Thuoc tinh ban kinh
        public int BanKinh
        {
            get
            {
                return banKinh;
            }

            set
            {
                banKinh = value;
            }
        }

        // Thuoc tinh tam
        public Point Tam
        {
            get
            {
                return tam;
            }

            set
            {
                tam = value;
            }
        }

        // Ham khoi dung
        public DuongTron(int banKinh, Point tam)
        {
            this.BanKinh = banKinh;
            this.Tam = tam;
        }        
    
        // Phuong thuc tinh chu vi
        public double ChuVi()
        {
            double chuVi = 2 * Math.PI * BanKinh;

            return chuVi;
        }

        // Phuong thuc tinh dien tich
        public double DienTich()
        {
            double dienTich = Math.PI * BanKinh * BanKinh;

            return dienTich;
        }    
    }

    struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
