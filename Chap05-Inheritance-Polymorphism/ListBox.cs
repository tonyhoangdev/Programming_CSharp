using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap05_Inheritance_Polymorphism
{
    // Lop ListBox dan xuat tu lop Window
    class ListBox : Window
    {
        // Khoi dung co tham so
        public ListBox(int top, int left, string theContents) : base(top, left) // Goi ham khoi dung cua lop co so
        {
            this.theContents = theContents;
        }

        // Tao mot phien ban moi cho phuong thuc DrawWindow
        // Vi lop dan xuat muon thay doi hanh vi thuc hien ben trong phuong thuc nay
        // Tu khoa override de chong len phuong thuc ao DrawWindow()
        public override void DrawWindow()
        {
            base.DrawWindow();
            Console.WriteLine("ListBox write: {0}", theContents);
        }

        // bien thanh vien
        private string theContents;
    }
}
