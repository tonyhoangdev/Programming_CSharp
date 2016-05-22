using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap11_Delegate_Event
{
    // Muc dich chinh cua Multicast Delegate la:
    // mot uy quyen co the thuc hien nhieu hon mot phuong thuc

    // Bat cu quy quyen nao tra ve gia tri void la uy quyen multicast
    // mac du vay ta co the doi u voi no nhu la uy quyen binh thuong cung khong sao

    // Them delegate vao delegate khac bang toan tu +=
    // Xoa delegate bang toan tu -=
    public class MulticastDelegate
    {

        public static void Main()
        {
            // Dinh nghia 3 String Delegate
            MyClassWithDelegate.StringDelegate Writer, Logger, Tranmitter;

            // Dinh nghia mot string delegate khac thuc hien milticasting
            MyClassWithDelegate.StringDelegate myMulticasting;

            // Tai the hien cua 3 delegate dau tine va truyen vao phuong thuc thuc thi
            Writer = new MyClassWithDelegate.StringDelegate(MyImplementingClass.WriteString);
            Logger = new MyClassWithDelegate.StringDelegate(MyImplementingClass.LogString);
            Tranmitter = new MyClassWithDelegate.StringDelegate(MyImplementingClass.TransmitString);

            // Goi phuong thuc delegate Writer
            Writer("String passed to Writer\n");
            // Goi phuong thuc delegate Logger
            Logger("String passed to Logger\n");
            // Goi phuong thuc delegate Transmitter
            Tranmitter("String passed to Transmitter\n");

            // Thong bao nguoi dung rang da ket hop 2 delegate vao trong mot multicast delegate
            Console.WriteLine("myMulticastDelegate = Writer + Logger");
            // Ket hop 2 delegate
            myMulticasting = Writer + Logger;
            // Goi phuong thuc delegate, hai phuong thuc se duoc thuc hien
            myMulticasting("First string passed to Collector");

            // Thong bao nguoi dung rang da them delegate thu 3 vao trong multicast delegate
            Console.WriteLine("\nmyMulticastDelegate += Transmitter");
            // them delegate thu 3 vao
            myMulticasting += Tranmitter;

            // goi thuc thi Multicast delegate, cung mot luc ba phuong thuc se cung duoc goi thuc hien
            myMulticasting("Second string passed to Collector");

            // Bao voi nguoi su dung rang xoa delegate Writer
            Console.WriteLine("\nmyMulticastDelegate -= Writer");
            // xoa delegate Writer
            myMulticasting -= Writer;
            // Goi lai delegate, luc nay chi con thuc hien hai phuong thuc
            myMulticasting("Third string passed to Collector");


            Console.ReadLine();
        }
    }

    public class MyClassWithDelegate
    {
        // Khai bao delegate
        public delegate void StringDelegate(string s);
    }

    public class MyImplementingClass
    {
        public static void WriteString(string s)
        {
            Console.WriteLine("Writing string {0}", s);
        }

        public static void LogString(string s)
        {
            Console.WriteLine("Logging string {0}", s);
        }

        public static void TransmitString(string s)
        {
            Console.WriteLine("Transmitting string {0}", s);
        }
    }

}
