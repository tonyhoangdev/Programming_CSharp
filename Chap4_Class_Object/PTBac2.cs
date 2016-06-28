using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap4_Class_Object
{
    class PTBac2
    {
        // Bien thanh vien
        private int a;
        private int b;
        private int c;
        private double x1 = 0;
        private double x2 = 0;

        // Ham khoi dung
        public PTBac2(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        // phuong thuc tinh delta
        private double Delta()
        {
            double delta = b * b - 4 * a * c;
            return delta;
        }

        // Tinh so luong nghiem
        public int TinhSoLuongNghiem()
        {
            if (Delta() > 0) return 2;
            else if (Delta() == 0) return 1;
            else return 0;
        }

        public bool TinhNghiem()
        {
            bool PtCoNghiem = true;

            if (TinhSoLuongNghiem() == 2)
            {
                x1 = (-b + Math.Sqrt(Delta())) / 2 / a;
                x2 = (-b - Math.Sqrt(Delta())) / 2 / a;
            }
            else if (TinhSoLuongNghiem() == 1)
            {
                x1 = x2 = -b / 2 / a;
            }
            else
            {
                PtCoNghiem = false;  
            }

            return PtCoNghiem;
        }

        // Thuoc tinh
        public int A
        {
            get
            {
                return a;
            }

            set
            {
                a = value;
            }
        }

        public int B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;
            }
        }

        public int C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }

        public double X1
        {
            get
            {
                return x1;
            }

            set
            {
                x1 = value;
            }
        }

        public double X2
        {
            get
            {
                return x2;
            }

            set
            {
                x2 = value;
            }
        }
    }
}
