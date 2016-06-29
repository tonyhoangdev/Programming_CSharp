using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
5.1. Ke thua - Da hinh
    - Dac biet hoa (specialization) duoc cai dat thong qua ke thua (inheritance):
    - Tong quat hoa - da hinh (polymophism): Cho phep cac the hien cua lop co lien he voi nhau
      co the xu ly theo mot cach tong quat.
    - Lop co lap (sealed class): khong cho ke thua
5.1.1. Tong quat hoa - Dac biet hoa
    - Dac biet hoa: qua he la mot (is-a) la mot su dac biet hoa:
      + e.g. Con meo la mot loai dong vat co vu,
      co nghia la chung ta noi rang con meo la truong hop dac biet cua loai dong vat co vu. 
    - Dac biet hoa va tong quat hoa la hai mot quan he doi ngau va phan cap voi nhau.
      + e.g. loai cho va meo la truong hop dac biet cua dong vat co vu.
      nguoc lai, dong vat co vu la truong hop tong quat tu loai cho va meo. 
5.1.2. Su ke thua
    - C#, quan he dac biet hoa duoc thuc thi bang cach su dung "su ke thua"
    - Thuc thi ke thua: de tao mot lop dan xuat tu mot lop ta them dau 2 cham vao sau ten lop dan xuat va truoc ten lop co so.
        public class ListBox : Window
    - Lop dan xuat cung co the tao phuong thuc moi bang viec danh dau voi tu khoa new.
5.1.3. Goi phuong thuc khoi dung cua lop co so
    - Cach goi duoc thuc hien bang viec dat dau hai cham ngay sau phan khai bao danh sach tham so
      va tham chieu den lop co so thong qua tu khoa base.
      + public ListBox(int top, int left,, string theContents) : base(top, left)
    - Luu y: Lop ListBox thuc thi mot phien ban moi cua phuong thuc DrawWindow su dung tu khoa new
      + public new void DrawWindow();
5.1.4. Goi phuong thuc cua lop co so
    - base.DrawWindow(); // goi phuong thuc co so
5.1.5. Dieu khien truy xuat
    - kha nang hien huu cua mot lop va cac thanh vien cua no co the duoc han che thong qua viec su dung cac
      bo sung truy cap: public, private, protected, internal, protected internal.
    - public: cho phep mot thanh vien co the duoc truy cap boi mot phuong thuc thanh vien cua lop khac
      private: chi cho phep cac phuong thuc thanh vien trong lop do truy cap.
      protected: mo rong cua private, cho phep truy cap tu lop dan xuat. 
      internal: mo rong kha nang cho phep bat cu phuong thuc cua lop nao trong cung mot khoi ket hop (assembly)
                co the truy xuat. mot khoi ket hop la mot khoi chia se va dung lai trong CLR. 
                (tap hop cac tap tin vat ly duoc luu tru trong mot thu muc gom: cac tap tin tai nguyen, chuong trinh thuc thi theo ngon ngu IL.)
      protected internal: cho phep cac thanh vien cua cung mot khoi asembly or cac lop dan xuat cua no co the truy cap.
    - e.g. myValue duoc khai bao truy xuat la protected ma du ban than lop la public...
      public class MyClass
      {
        // ..
        protected int myValue;
      }
5.1.6. Da hinh
5.1.7. Phuong thuc da hinh
    - de tao mot phuong thuc ho tro tinh da hinh, chung ta can khai bao khoa virtual trong phuong thuc cua lop co so.
    - e.g. de chi dinh rang phuong thuc DrawWindow() cua lop Window la da hinh, ta them tu khoa virtual vao khai bao
        public virtual void DrawWindow();
    - Trong class dan xuat, Thuc thi phu quyet phuong thuc cua lop co so dung tu khoa override.
        public override void DrarWindow()
5.1.8. Tu khoa new va override
    - override: de phu quyet phuong thuc ao cua lop co so
        public override void DrawWindow();
    - new: khong phai phu quyet cua bat cu phuong thuc ao nao trong lop co so
        public new virtual void DrawWindow();
5.1.9. Lop truu tuong
    - Khong the tao the hien duoc tu lop truu tuong.
    - Phuong thuc truu tuong: chi don gian tao ra mot ten phuong thuc va ki hieu cua phuong thuc,
      va phuong thuc nay se duoc thuc thi o lop dan xuat.
    - Neu lop dan xuat khong thuc thi, thi lop dan xuat do cung la lop truu tuong va khong the tao duoc the hien cua lop.
    - khai bao: phuong thuc khong can thuc thi nen khong can dau {}
      + abstract public void DrawWindow();
    - Neu khai bao mot hay nhieu phuong thuc la truu tuong thi phai khai bao lop la abstract.
      + abstract public class Window {}
    - Han che cua lop truu tuong:
      + Khong co su thuc thi can ban. Chung the hien y tuong ve mot su truu tuong,
        Dieu nay thiet lap mot giao uoc cho tat ca cac lop dan xuat
      => Noi cach khac, lop truu tuong mo ta mot phuong thuc chung cua tat ca cac lop duoc thuc thi mot cac truu tuong.
5.1.10. Lop co lap (sealed class)
    - Khong cho phep dan xuat
5.1.11. Goc cua tat ca cac lop: lop Object
    - Moi class deu duoc dan xuat tu lop Object
5.1.12. Boxing and Unboxing du lieu
    - Boxing la su chuyen doi ngam dinh cua mot kieu du lieu gia tri sang kieu du lieu tham chieu la doi tuong.
    - Unboxing la dua mot doi tuong ra mot gia tri phai duoc thuc hien mot cach tuong minh.
    - Khi unboxing phai theo 2 buoc:
        + Phai chan chan rang doi tuong da boxing dung kieu gia tri dua ra
        + Sao chep gia tri tu the hien hay doi tuong va bien kieu gia tri.
    - e.g.
        + int i = 123; // kieu du lieu gia tri
        + object o = i; // Boxing ngam dinh
        + int k = (int)o; // Unboxing tuong minh
    - Thong thuong chung ta bao boc unboxing trong khoi try, neu unboxing null or tham chieu den mot doi tuong khac kieu du lieu,
      mot InvalidCastException se duoc phat sinh.
5.1.13. Lop Long (Nested class)
    - Lop long hay la lop noi duoc khai bao voi tu khoa internal, chua ben trong pham vi cua mot lop.
    - Lop noi co the truy cap duoc cac thanh vien  private cua lop ma no chua ben trong.
*/
namespace Chap05_Inheritance_Polymorphism
{
    class Tester
    {
        public static void Main()
        {
            //
            Console.WriteLine("Test chap 05");

            // tao doi tuong cho lop co so
            Window w = new Window(2, 3);
            w.DrawWindow();

            // tao doi tuong cho lop dan xuat
            ListBox lb = new ListBox(20, 10, "Hello world!");
            lb.DrawWindow();

            // Kiem tra tinh da hinh
            // Tung doi tuong thuc hien cong viec cua no
            Window win = new Window(1, 2);
            ListBox lb1 = new ListBox(2, 4, "Stand alone list box");
            win.DrawWindow();
            lb1.DrawWindow();
            // Thuc hien cong viec duoc goi tu lop tong quat
            Console.WriteLine("Da hinh");
            Window[] winArray = new Window[2];
            winArray[0] = new Window(4, 5);
            winArray[1] = new ListBox(5, 6, "List box is array");
            for (int i = 0; i < 2; i++)
            {
                winArray[i].DrawWindow();
            }


            // Boxing and Unboxing
            Console.WriteLine("Boxing and Unboxing");
            int j = 123;
            // boxing
            object o = j;
            // unboxing phai duoc tuong minh
            int k = (int)o;
            Console.WriteLine("k: {0}", k);


            // Bai tap da hinh dog and cat
            Console.WriteLine("Bai tap da hinh dog and cat");
            Animal[] animalArray = new Animal[2];
            animalArray[0] = new Dog("Lu Lu", "Vang");
            animalArray[1] = new Cat("Mun", 5);
            for (int i = 0; i< 2; i++)
            {
                animalArray[i].Who();
            }
            {

            }

            Console.ReadLine();
        }
    }
}
