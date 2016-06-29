using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap05_Inheritance_Polymorphism
{
    abstract public class Animal
    {
        // Ham khoi dung
        public Animal(string name)
        {
            this.name = name;
        }

        // Phuong thuc truu tuong minh hoa viec dua ten cua doi tuong
        abstract public void Who();

        // Bien thanh vien
        protected string name;
    }

    // Lop Dog dan xuat tu lop animal
    public class Dog : Animal
    {
        // bien thanh vien
        private string color;

        // ham khoi dung lay 2 tham so
        public Dog(string name, string color) : base(name)
        {
            this.color = color;
        }

        // phu quyet phuong thuc truu tuong Who()
        public override void Who()
        {
            Console.WriteLine("Gu gu! Toi la {0} co mau long {1}", name, color);
        }
    }

    // Lop Cat dan xuat tu lop Animal
    public class Cat : Animal
    {
        // Bien thanh vien
        private int weight;

        // Ham khoi dung lay hai tham so
        public Cat(string name, int weight) : base(name)
        {
            this.weight = weight;
        }

        // Thuc hien phu quyet phuong thuc truu tuong Who()
        public override void Who()
        {
            Console.WriteLine("Meo meo! Toi la {0} can nang {1}", name, weight);
        }
    }
}
