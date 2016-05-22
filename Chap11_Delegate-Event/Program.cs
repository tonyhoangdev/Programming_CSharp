using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap11_Delegate_Event
{
    // khai bao kieu liet ke
    public enum comparison
    {
        theFirstComesFirst = 1,
        theSecondComesFirst = 2
    }

    // Lop Pair don gian luu tru 2 doi tuong
    public class Pair
    {
        // Khai bao uy quyen
        public delegate comparison WhichIsFirst(object obj1, object obj2);

        // dua vao 2 doi tuong theo thu tu
        public Pair(object firstObj, object secondObj)
        {
            thePair[0] = firstObj;
            thePair[1] = secondObj;
        }

        // Sap xep theo thu tu cua hai doi tuong
        // theo bat cu tieu chuan nao cua doi tuong
        public void Sort(WhichIsFirst theDelegateFunc)
        {
            if (theDelegateFunc(thePair[0], thePair[1]) == comparison.theSecondComesFirst)
            {
                object temp = thePair[0];
                thePair[0] = thePair[1];
                thePair[1] = temp;
            }
        }

        // sap xeo hai doi tuong theo thu tu nghich dao
        public void ReverseSort(WhichIsFirst theDelegateFunc)
        {
            if (theDelegateFunc(thePair[0], thePair[1]) == comparison.theFirstComesFirst)
            {
                object temp = thePair[0];
                thePair[0] = thePair[1];
                thePair[1] = temp;
            }
        }

        public override string ToString()
        {
            // xuat thu tu doi tuong thu nhat truoc doi tuong thu hai
            return thePair[0].ToString() + ", " + thePair[1].ToString();
        }

        // bien luu giu hai doi tuong
        private object[] thePair = new object[2];
    }

    // lop doi tuong Cat
    public class Cat
    {
        // bien luu trong luong
        private int weight;

        public Cat(int weight)
        {
            this.weight = weight;
        }

        // sap xep theo thu tu trong luong
        public static comparison WhichCatComesFirst(object o1, object o2)
        {
            Cat c1 = (Cat)o1;
            Cat c2 = (Cat)o2;
            return c1.weight > c2.weight ? comparison.theSecondComesFirst : comparison.theFirstComesFirst;
        }

        // Khai bao uy quyen Tinh
        // readonly de ghi chu rang, khi mot truong da duoc tao ra thi khong duoc bo sung sau do
        //public static readonly Pair.WhichIsFirst OrderCats = new Pair.WhichIsFirst(Cat.WhichCatComesFirst);

        // Dung uy quyen nhu thuoc tinh
        public static Pair.WhichIsFirst OrderCats
        {
            get
            {
                return new Pair.WhichIsFirst(WhichCatComesFirst);
            }
        }

        //
        public override string ToString()
        {
            return weight.ToString();
        }
    }

    // lop student
    public class Student
    {
        // bien luu tru ten
        private string name;

        public Student(string name)
        {
            this.name = name;
        }

        // sap xep theo thu tu chu cai
        public static comparison WhichStudentComesFirst(object o1, object o2)
        {
            Student s1 = (Student)o1;
            Student s2 = (Student)o2;

            return (String.Compare(s1.name, s2.name) < 0) ? comparison.theFirstComesFirst : comparison.theSecondComesFirst;
        }

        // Khai bao uy quyen Tinh
        // readonly de ghi chu rang, khi mot truong da duoc tao ra thi khong duoc bo sung sau do
        //public static readonly Pair.WhichIsFirst OrderStudents = new Pair.WhichIsFirst(Student.WhichStudentComesFirst);

        // Dung uy quyen nhu thuoc tinh
        public static Pair.WhichIsFirst OrderStudents
        {
            get
            {
                return new Pair.WhichIsFirst(WhichStudentComesFirst);
            }
        }

        //
        public override string ToString()
        {
            return name.ToString();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // tao hai doi tuong Student va Cat
            // dua chung vao hai doi tuong Pair
            Student Thao = new Student("Thao");
            Student Mai = new Student("Mai");
            Cat Mun = new Cat(5);
            Cat Ngao = new Cat(2);
            Pair studentPair = new Pair(Thao, Mai);
            Pair catPair = new Pair(Mun, Ngao);
            Console.WriteLine("Sinh vien \t\t: {0}", studentPair.ToString());
            Console.WriteLine("Meo \t\t\t: {0}", catPair.ToString());

            // tao uy quyen
            Pair.WhichIsFirst theStudentDelegate = new Pair.WhichIsFirst(Student.WhichStudentComesFirst);
            Pair.WhichIsFirst theCatDelegate = new Pair.WhichIsFirst(Cat.WhichCatComesFirst);

            // sap xep dung uy quyen
            studentPair.Sort(theStudentDelegate);
            Console.WriteLine("Sau khi sap xep studentPair\t\t: {0}", studentPair.ToString());

            //studentPair.ReverseSort(theStudentDelegate);
            // Thuc hien uy quyen ma khong can khai bao the hien uy quyen cuc bo
            studentPair.ReverseSort(Student.OrderStudents);
            Console.WriteLine("Sau khi sap xep nguoc studentPair\t\t: {0}", studentPair.ToString());

            catPair.Sort(theCatDelegate);
            Console.WriteLine("Sau khi sap xep catPair\t\t: {0}", catPair.ToString());
            //catPair.ReverseSort(theCatDelegate);
            // Thuc hien uy quyen ma khong can khai bao the hien uy quyen cuc bo
            catPair.ReverseSort(Cat.OrderCats);
            Console.WriteLine("Sau khi sap xep nguoc catPair\t\t: {0}", catPair.ToString());

            Console.ReadLine();
        }
    }
}
