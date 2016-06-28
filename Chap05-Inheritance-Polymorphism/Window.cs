using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap05_Inheritance_Polymorphism
{
    class Window
    {
        // Ham khoi dung lay hai so nguyen chi den vi tri cua cua so tren console
        public Window(int top, int left)
        {
            this.top = top;
            this.left = left;
        }

        // Mo phong ve cua so
        public virtual void DrawWindow()
        {
            Console.WriteLine("Drawing window at {0}, {1}", top, left);
        }

        // Bien thanh vien private
        // se khong thay duoc trong lop dan xuat
        private int top;
        private int left;
    }
}
