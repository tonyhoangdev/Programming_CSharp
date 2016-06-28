using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** 
4.1. Dinh nghia lop (Khai bao)
[Thuoc tinh][Bo sung truy cap] class <Dinh danh lop> [: lop co so]
{
    <Phan than cua lop: Bao gom dinh nghia cac thuoc tinh va phuong thuc hanh dong> 
}
4.1.1. Thuoc tinh truy cap
    public, private, protected, internal, protected internal.
4.1.2. Tham so cua phuong thuc
    void Method(int p1, button p2)
    {
        //...
    }
4.1.3. Tao doi tuong
    ThoiGian t = new ThoiGian();
    // Cac kieu di lieu chuan nhu int, float, char,... la nhung kieu du lieu gia tri, duoc luu tren Stack
    // Cac kieu du lieu tham chieu thi duoc tao ra tren heap, su dung tu khoa new de tao mot doi tuong
4.1.4. Bo khoi dung
    - Cau lenh tao doi tuong tuong tu nhu viec goi thuc hien mot phuong thuc
        ThoiGian t = new ThoiGian();
    => Mot phuong thuc se duoc goi khi chung ta tao mot doi tuong.
    - Phuong thuc nay duoc goi la bo khoi dung (constructor)
    - Khai bao: Co ten trung ten lop, khong co gia tri tra ve, duoc khai bao la public
        public Thoigian(type_t p1)
        {

        }
    - Gia tri mac dinh cua cac kieu du lieu co ban khi khoi tao
        int, long, byte,...     0
        bool                    false
        char                    '\0' (null)
        enum                    0
        reference               null
4.1.5. Khoi tao bien thanh vien
    - Gan gia tri cho mot bien:
        private Giay = 30; // Khoi tao
4.1.6. Bo khoi dung sao chep
    - Tao mot doi tuong moi bang cach sao chep tat ca cac bien tu doi tuong da co vao cung mot kieu du lieu.
    public ThoiGian(ThoiGian tg)
    {
        Nam = tg.Nam;
        Thang = tg.Thang;
        Ngay = tg.Ngay;
        Gio = tg.Gio;
        Phut = tg.Phut;
        Giay = tg.Giay;
    }
4.1.7. Tu khoa this
    - Tham chieu den the hien hien hanh cua doi tuong
    - Duoc su dung theo cac cach:
        + Su dung khi cac bien thanh vien bi che lap boi tham so dua vao
            public void SetYear(int Nam)
            {
                this.Nam = Nam;
            }
        + Truyen doi tuong hien hanh vao mot tham so cua mot phuong thuc cua doi tuong khac
            public void Method1(OtherClass otherObject)
            {
                // Su dung tham chieu this de truyen tham so la ban than doi tuong dang thuc hien
                otherObject.SetObject(this);
            }
        + SU dung tham chieu this la mang chi muc (indexer)...

*/
namespace Chap4_Class_Object
{
    class Tester
    {
        public static void Main()
        {
            // Khoi tao doi tuong 1 voi ham khoi dung DateTime
            ThoiGian t1 = new ThoiGian(DateTime.Now);
            t1.ThoiGianHienHanh();

            // Khoi tao doi tuong 2 voi ham khoi dung co bien thanh vien mac dinh
            ThoiGian t2 = new ThoiGian(2016, 06, 27, 14, 32);
            t2.ThoiGianHienHanh();

            // Khoi tao doi tuong 3 voi ham khoi dung sao chep
            ThoiGian t3 = new ThoiGian(t1);
            t3.ThoiGianHienHanh();

            // Phuong thuc
            int var1 = 5;
            float var2 = 10.5f;
            Parameter pa = new Parameter();
            pa.SomeMethod(var1, var2);

            Console.ReadLine();
        }
    }
}
