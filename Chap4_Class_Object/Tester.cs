using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        private giay = 30; // Khoi tao
4.1.6. Bo khoi dung sao chep
    - Tao mot doi tuong moi bang cach sao chep tat ca cac bien tu doi tuong da co vao cung mot kieu du lieu.
    public ThoiGian(ThoiGian tg)
    {
        nam = tg.nam;
        thang = tg.thang;
        ngay = tg.ngay;
        gio = tg.gio;
        phut = tg.phut;
        giay = tg.giay;
    }
4.1.7. Tu khoa this
    - Tham chieu den the hien hien hanh cua doi tuong
    - Duoc su dung theo cac cach:
        + Su dung khi cac bien thanh vien bi che lap boi tham so dua vao
            public void SetYear(int nam)
            {
                this.nam = nam;
            }
        + Truyen doi tuong hien hanh vao mot tham so cua mot phuong thuc cua doi tuong khac
            public void Method1(OtherClass otherObject)
            {
                // Su dung tham chieu this de truyen tham so la ban than doi tuong dang thuc hien
                otherObject.SetObject(this);
            }
        + SU dung tham chieu this la mang chi muc (indexer)...
4.1.8. Su dung cac thanh vien tinh (static member)
    - Nhung thuoc tinh va phuong thuc cua mot lop co the la nhung thanh vien the hien (instance members) 
      or nhung thanh vien tinh (static members).
    - Truy cap den thanh vien tinh cua mot lop thong qua ten lop
    - e.g. mot lop Button co 2 the hien la btnUpdate and btnDelete va co mot phuong thuc tinh la Show()
        + truy cap phuong thuc tinh dung Button.Show() dung hon la btnUpdate.Show() khong duoc cho phep trong C#
4.1.9. Goi mot phuong thuc tinh
    - Phuong thuc tinh duoc xem nhu la phan hoat dong cua lop hon la cua the hien mot lop.
      Chung khong cam co mot tham chieu this hay bat cu the hien nao tham chieu toi
    - Phuong thuc tinh khong the truy cap truc tiep den cac thanh vien khong co tinh chat tinh (nonstatic).
      Nhu vay ham Main() khong the goi mot phuong thuc khong tinh ben trong lop.
    - De phuong thuc tinh goi mot phuong thuc khong tinh thong qua mot the hien cua lop.
4.1.10. Su dung bo khoi dung tinh
    - Neu mot lop khai bao mot bo khoi dung tinh (static constructor), thi duoc dam bao rang 
      phuong thuc khoi dung tinh nay se duoc goi truoc bat cu the hien nao cua lop duoc tao ra.
    - e.g. Bo khoi dung tinh thoi gian, truy cap den bien thanh vien tinh ten.
        private static string ten;
        static ThoiGian()
        {
            ten = "Thoi Gian";
        }
        public voi ThoiGianHienHanh()
        {
            // ...
        }
4.1.11. Su dung bo khoi dung private
    - Ngan ngua viec tao bat cu the hien cua lop, ta tao bo khoi dung khong tham so, khong lam gi ca, va thuoc tinh private
        private ThoiGian()
        {}
4.1.12. Su dung cac thuoc tinh tinh
    - Su dung bien thanh vien tinh de dem so the hien cua mot lop duoc tao ra.
4.1.13. Huy doi tuong
    - C# cung cap co che thu don (garbage collection) va do vay khong can phai khai bao tuong minh cac phuong thuc huy.
    - Tuy nhien, khi lam viec voi cac doan ma khong duoc quan ly thi can phai khai bao tuong minh cac phuong thuc huy de giai phong tai nguyen.
    - Phuong thuc Finalize() con goi la bo ket thuc, se duoc goi boi co che thu don khi doi tuong bi huy.
    - Phuong thuc Finalize() chi giai phong cac tai nguyen ma doi tuong nam giu, khong tham chieu den cac doi tuong khac.
        -> chung ta chi lam dieu nay khi xu ly cac tai nguyen khong kiem soat duoc
    - Chung ta goi phuong nay nay cua lop co so.
4.1.14. Bo huy cua C#
    - cu phap:
        ~Class() // tranh viet
        {
            // Thuc hien mot so cong viec
        }      
    or tuong tu nhau
        Class.Finalize() // dung cach tuong minh neu su dung
        {
            // Thuc hien mot so cong viec
            base.Finalize();
        }
4.1.15. Phuong thuc Dispose
    - Neu chung ta xu ly cac tai nguyen khong kiem soat nhu: handle cac tap tin 
      va ta muon dong va giai phong nhanh chong bat cu luc nao, ta thuc thi giao dien IDisposable.
    - Y nghia: cho phep chuong trinh thuc hien cac cong viec don dep hay giai phong tai nguyen mong muon 
      ma khong phai cho cho den khi phuong thuc Finalize() duoc goi.
    - Cung cap phuong thuc Dispose thi phai ngung bo thu don goi phuong thuc Finalize() trong doi tuong cua chung ta.
    - De ngung bo thu don, chung ta goi mot phuong thuc tinh cua lop GC (Garbage Collection) la GC.SuppressFinalize()
      va truyen tham so la this cua doi tuong.
    - e.g.
        public void Dispose()
        {
            // thuc hien cong viec don dep
            // Yeu cau bo thu don GC thuc hien ket thuc
            GC.SuppressFinalize();
        } 
        public override void Finalize()
        {
            Dispose();
            base.Finalize();
        }
4.1.16. Phuong thuc Close
    - Khi xay dung doi tuong, chung ta muon cung cap cho nguoi su dung phuong thuc Close(),
      vi no co ve tu nhien hon phuong thuc Dispose trong cac doi tuong co lien quan den xu ly tap tin
    - Ta co the xay dung phuong thuc Close la public va goi den phuong thuc Dispose private.
4.1.17. Cau lenh using
    - su dung using de dam bao phuong thuc Dispose se duoc goi som nhat co the.
    - using (doi tuong)
      {}
    -> Khi khoi pham vi nay ket thuc, thi phuong thuc Dispose() cua doi tuong se duoc goi mot cach tu dong.
    - e.g.
            using (Font aFont = new Font("Arial", 10.0f)
            {
                // Doa su dung aFont
            } // Trinh bien dich se goi Dispose de giai phong aFont

            Font tFont = new Font("Tahoma", 12.0f);
            using (tFont)
            {
                // Doa su dung tFont    
            } // Trinh bien dich se goi Dispose de giai phong tFont
4.1.18. Truyen tham so
    - bo sung tham so ref: cho phep truyen cac doi tuong gia tri vao theo phuong thuc tham chieu
    - bo sung tham so out: cho phep truyen duoi dang tham chieu ma khong can phai khoi tao gia tri ban dau cho tham so truyen.
    - bo sung tham so params: cho phep phuong thuc chap nhan nhieu so luong cac tham so.
4.1.19. Truyen tham chieu
    - ref: phai khoi tao cho bien truoc khi truyen tham so 
    - out: Khong can khoi tao bien truoc
4.1.20. Nap chong phuong thuc
    - tao nhieu ham cung ten:
    - cung ten method, khac ve so luong tham so, kieu tham so, kieu gia tri tra ve.
4.1.21. Dong goi du lieu voi thanh phan thuoc tinh
    - Cung cap mot giao dien don gian cho phep truy cap cac bien thanh vien.
    - Tuy nhien cach thuc thuc thi truy cap giong nhu phuong thuc, trong do cac du lieu duoc che dau,
      dam bao cho yeu cau thiet ke huong doi tuong.
    - truy cap lay du lieu (get accessor)
        get {return Nam;}
    - truy cap thiet lap du lieu (set accessor)
        set {Nam = value;}
4.1.22. Thuoc tinh chi doc
    - Muon danh dau thuoc tinh nay khong duoc thay doi.
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

            // Get time dung tham chieu ref
            int gio = 0, phut = 0, giay = 2;
            t3.GetTime(ref gio, ref phut, ref giay);
            Console.WriteLine("get time: {0}:{1}:{2}", gio, phut, giay);

            // Get date dung tham chieu out
            int nam, thang, ngay;
            t3.GetDay(out nam, out thang, out ngay);
            Console.WriteLine("Get day: {0}/{1}/{2}", nam, thang, ngay);

            // Truy cap bang thuoc tinh
            // Lay du lieu tu thuoc tinh
            int pNam = t3.Nam;
            Console.WriteLine("Lay Nam: {0}", pNam);
            pNam++;
            t3.Nam = pNam;
            Console.WriteLine("Update Nam: {0}", pNam); 

            // Phuong thuc
            Console.WriteLine();
            int var1 = 5;
            float var2 = 10.5f;
            Parameter pa = new Parameter();
            pa.SomeMethod(var1, var2);

            // Dem so luong Cats
            Console.WriteLine();
            Cat.HowManyCats();
            Cat mun = new Cat();
            Cat.HowManyCats();
            Cat muop = new Cat();
            Cat miu = new Cat();
            Cat.HowManyCats();

            // su dung using
            Console.WriteLine();
            
            Console.ReadLine();
        }
    }
}
