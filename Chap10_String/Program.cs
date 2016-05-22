using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chap10_String
{
    class Program
    {
        static void Main(string[] args)
        {
            // WorkWithString();
            //FindString();
            //SplitString();
            //RegularExpression();
            //RegularExpressionStatic();
            //RegularExpressionCollection();
            //RegularExpressionCollectionGroups();
            RegularExpressionCollectionGroupsCapture();
        }

        private static void WorkWithString()
        {
            // Khoi tao mot so chuoi de thao tac
            string s1 = "abcd";
            string s2 = "ABCD";
            string s3 = @"Trung tam dao tao cntt 
    Thanh pho Ho Chi Minh Viet Nam";
            int result;
            // So sanh hai chuoi voi nhau co phan biet chu thuong va chu hoa
            result = string.Compare(s1, s2);
            Console.WriteLine("So sanh hai chuoi s1: {0} va s2: {1}, ket qua: {2} \n", s1, s2, result);

            // Su dung tiep phuong thuc Compare() nhung truong hop nay khong phan biet
            // chu thuong hay chu hoa
            // tham so thu ba la true se bor qua kiemtra ky tu thuong - hoa
            result = string.Compare(s1, s2, true);
            Console.WriteLine("Khong phan biet chu thuong va chu hoa\n");
            Console.WriteLine("s1: {0}, s2: {1}, ket qua: {2} \n", s1, s2, result);
            // phuong thuc noi cac chuoi
            string s4 = string.Concat(s1, s2);
            Console.WriteLine("Chuoi s4 noi tu chuoi s1 va s2: {0}", s4);
            // su dung nap chong toan tu +
            string s5 = s1 + s2;
            Console.WriteLine("Chuoi s5 noi tu chuoi s1 va s2: {0}", s5);
            // Su dung phuong thuc copy chuoi
            string s6 = string.Copy(s5);
            Console.WriteLine("Chuoi s6 duoc sao chep tu s5: {0}", s6);
            // su dung nap chong toan tu = 
            string s7 = s6;
            Console.WriteLine("s7 = s6: {0}", s7);
            // Su dung ba cach so sanh hai chuoi
            // cach 1 su dung mot chuoi de so sanh voi chuoi con lai
            Console.WriteLine("S6.Equals(S7) ?: {0}", s6.Equals(s7));
            // cach 2 dung ham cua lop string so sanh hai chuoi
            Console.WriteLine("Equals(S6, S7) ?: {0}", string.Equals(s6, s7));
            // cach 3 dung toan tu so sanh
            Console.WriteLine("S6 == S7 ?: {0}", s6 == s7);
            // su dung hai thuoc tinh hay dung la chi muc va chieu dai cua chuoi
            Console.WriteLine("\nChuoi s7 co chieu dai la: {0}", s7.Length);
            Console.WriteLine("Ky tu thu 3 cua chuoi s7 la: {0}", s7[2]);
            // Kiem tra xem mot chuoi co ket thuc voi mot nhom ky tu xac dinh hay khong
            Console.WriteLine("S3: {0}\n Ket thuc voi chu cntt? : {1}\n", s3, s3.EndsWith("cntt"));
            Console.WriteLine("S3: {0}\n Ket thuc voi chu Nam? : {1}\n", s3, s3.EndsWith("Nam"));
            // tra ve chi muc cua mot chuoi con
            Console.WriteLine("\nTim vi tri xuat hien dau tien cua chu cntt ");
            Console.WriteLine("trong chuoi s3 la {0}\n", s3.IndexOf("cntt"));
            // chen tu nhan luc vao truoc cntt trong chuoi s3
            string s8 = s3.Insert(18, "nhan luc ");
            Console.WriteLine("s8: {0}\n", s8);
            // ngoai ra ta co the ket hop nhu sau
            string s9 = s3.Insert(s3.IndexOf("cntt"), "nhan luc cua ");
            Console.WriteLine("s9: {0}", s9);
            Console.ReadLine();
        }

        private static void FindString()
        {
            // Khai bao cac chuoi de su dung
            string s1 = "Mot hai ba bon";

            int ix;
            // Lay chi so cua khoan trang cuoi dung
            ix = s1.LastIndexOf(" ");
            // lay tu cuoi cung
            string s2 = s1.Substring(ix + 1);
            // thiet lap lai chuoi s1 tu vi tri 0 den vi tri ix
            // do do s1 co gia tri moi la Mot hai ba
            s1 = s1.Substring(0, ix);
            // tim chi so chua khoang trang cuoi cung (sau hai)
            ix = s1.LastIndexOf(" ");
            // Thiet lap s3 la chuoi con bat dau tu vi tri ix
            // do do s3 = "ba"
            string s3 = s1.Substring(ix + 1);
            // thiet lap lai s1 bat dau tu vi tri 0 den cuoi vi tri ix
            // s1 = "Mot hai"
            s1 = s1.Substring(0, ix);
            // ix chi den khoang trang giua "mot" va "hai"
            ix = s1.LastIndexOf(" ");
            // tao ra s4 la chuoi con bat dau tu sau vi tri ix
            // do vay co gia tri la "hai"
            string s4 = s1.Substring(ix + 1);
            // thiet lap lai gia tri cua s1
            s1 = s1.Substring(0, ix);
            // lay chi so cua khoang trang cuoi cung, luc nay ix la -1
            ix = s1.LastIndexOf(" ");
            // tao ra chuoi s3 bat dau tu chi so khoang trang, nhung khong co khoang
            // trang va ix la -1 nen chuoi bat dau tu 0
            string s5 = s1.Substring(ix + 1);
            Console.WriteLine("s2: {0}\n s3: {1}", s2, s3);
            Console.WriteLine("s4: {0}\n s5: {1}", s4, s5);
            Console.WriteLine("s1: {0}\n", s1);

            Console.ReadLine();
        }

        private static void SplitString()
        {
            // tao cac chuoi de lam viec
            string s1 = "Mot, hai, ba trung tam dao tao cntt";
            // tao ra hang ky tu khoan trang va dau phay
            const char Space = ' ';
            const char Comma = ',';
            // tao ra mang phan cach
            char[] delimiters = new char[] { Comma, Space };

            // Su dung StringBuilder de tao chuoi output
            StringBuilder output = new StringBuilder();
            int ctr = 1;
            // thuc hien viec chia mot chuoi dung vong lap
            // dua ket qua vao mang cac huoi
            foreach (string subString in s1.Split(delimiters))
            {
                output.AppendFormat("{0}: {1}\n", ctr++, subString);
            }
            Console.WriteLine(output);

            Console.ReadLine();
        }

        private static void RegularExpression()
        {
            // tao cac chuoi de lam viec
            string s1 = "Mot, hai, ba trung tam dao tao cntt";
            // tai chuoi bieu thuc quy tac
            Regex theRegex = new Regex(" |, ");
            StringBuilder sBuilder = new StringBuilder();
            int id = 1;
            // Su dung vong lap de lay cac chuoi con
            foreach (string subString in theRegex.Split(s1))
            {
                // noi chuoi vua tim duoc trong buoi thuc quy tac
                // vao chuoi StringBuilder theo dinh dang san
                sBuilder.AppendFormat("{0}: {1}\n", id++, subString);
            }
            Console.WriteLine("{0}", sBuilder);

            Console.ReadLine();
        }

        private static void RegularExpressionStatic()
        {
            // tao cac chuoi de lam viec
            string s1 = "Mot, hai, ba trung tam dao tao cntt ha ha";
            // tai chuoi bieu thuc quy tac
            StringBuilder sBuilder = new StringBuilder();
            int id = 1;
            // Su dung vong lap de lay cac chuoi con
            foreach (string subString in Regex.Split(s1, " |, "))
            {
                // noi chuoi vua tim duoc trong buoi thuc quy tac
                // vao chuoi StringBuilder theo dinh dang san
                sBuilder.AppendFormat("{0}: {1}\n", id++, subString);
            }
            Console.WriteLine("{0}", sBuilder);

            Console.ReadLine();
        }

        private static void RegularExpressionCollection()
        {
            // tao cac chuoi de lam viec
            string s1 = "Ngon ngu lap trinh C Sharp";
            // Tim bat cu chuoi con nao khong co khonag trang ben trong
            // va ket thuc la khoang trang
            Regex theReg = new Regex(@"(\S+)\s");
            // tao tap hop va nhan ket qua so khop
            MatchCollection theMatches = theReg.Matches(s1);
            // Su dung vong lap de lay cac chuoi trong tap hop
            foreach (Match theMatch in theMatches)
            {
                Console.WriteLine("Chieu dai: {0}", theMatch.Length);
                // Neu ton tai chuoi thi xuat ra
                if (theMatch.Length != 0)
                {
                    Console.WriteLine("Chuoi: {0}", theMatch.ToString());
                }
            }

            Console.ReadLine();
        }

        private static void RegularExpressionCollectionGroups()
        {
            // tao cac chuoi de lam viec
            string s1 = "18:30:12 10.207.218.100 fsoft.com.vn" +
                " 18:41:30 216.58.203.14 google.com";
            // Nhom thoi gian bang mot hay nhieu con so hay dau :
            // va theo sau boi khoan trang.
            Regex theReg = new Regex(@"(?<time>(\d|\:)+)\s" +
            // dia chi IP la mot hay nhieu con so hay dau cham
            // theo sau boi khoang trang
            @"(?<ip>(\d|\.)+)\s" +
                // dia chi web la mot hay nhieu ky tu
            @"(?<site>\S+)");
            // tao tap hop va nhan ket qua so khop
            MatchCollection theMatches = theReg.Matches(s1);
            // Su dung vong lap de lay cac chuoi trong tap hop
            foreach (Match theMatch in theMatches)
            {
                Console.WriteLine("\nLength: {0}", theMatch.Length);
                // Neu ton tai chuoi thi xuat ra
                if (theMatch.Length != 0)
                {
                    Console.WriteLine("theMatch: {0}", theMatch.ToString());
                    // hien thi thoi gian
                    Console.WriteLine("Time: {0}", theMatch.Groups["time"]);
                    // hien thi dia chi ip
                    Console.WriteLine("IP: {0}", theMatch.Groups["ip"]);
                    // hien thi dia chi web site
                    Console.WriteLine("Site: {0}", theMatch.Groups["site"]);
                }
            }

            Console.ReadLine();
        }

        // Khi phan tich mot chuoi trong đó có nhóm tên a xuất hiện hai lần
        // để nhóm chúng lại trong chuỗi tìm thấy chúng ta tạo nhóm ?<a> xuất hiện ở hai nơi
        // khi dùng Groups["a"] thì nó sẽ hiển thị chuỗi xuất hiện cuối cùng lần 2, và chuỗi lần đầu sẽ bị che mất
        // vì vậy dùng Groups["a"].Captures để lấy hết các chuỗi đã tìm được xuất hiện ở 2 nơi khác nhau.
        private static void RegularExpressionCollectionGroupsCapture()
        {
            // tao cac chuoi de lam viec
            // Luu y la ten cong ty duoc xuat hien
            // ca hai noi
            string s1 = "18:30:12 FSOFT 10.207.218.100 NXP" +
                " 18:41:30 GOOGLE 216.58.203.14 FB";
            // Nhom thoi gian bang mot hay nhieu con so hay dau :
            // va theo sau boi khoan trang.
            Regex theReg = new Regex(@"(?<time>(\d|\:)+)\s" +
            // ten cong ty
            @"(?<company>\S+)\s" +
            // dia chi IP la mot hay nhieu con so hay dau cham
            // theo sau boi khoang trang
            @"(?<ip>(\d|\.)+)\s" +
                // dia chi web la mot hay nhieu ky tu
            @"(?<company>\S+)");
            // tao tap hop va nhan ket qua so khop
            MatchCollection theMatches = theReg.Matches(s1);
            // Su dung vong lap de lay cac chuoi trong tap hop
            foreach (Match theMatch in theMatches)
            {
                Console.WriteLine("\nLength: {0}", theMatch.Length);
                // Neu ton tai chuoi thi xuat ra
                if (theMatch.Length != 0)
                {
                    Console.WriteLine("theMatch: {0}", theMatch.ToString());
                    // hien thi thoi gian
                    Console.WriteLine("Time: {0}", theMatch.Groups["time"]);
                    // hien thi dia chi ip
                    Console.WriteLine("IP: {0}", theMatch.Groups["ip"]);
                    // hien thi dia chi web site
                    Console.WriteLine("Company: {0}", theMatch.Groups["company"]);
                    // lap qua tap hop Capture de lay nhom company
                    foreach (Capture cap in theMatch.Groups["company"].Captures)
                    {
                        Console.WriteLine("Capture: {0}", cap.ToString());
                    }
                }
            }

            Console.ReadLine();
        }

    }
}
