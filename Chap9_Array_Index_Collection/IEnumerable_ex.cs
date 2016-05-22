using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap9_Array_Index_Collection
{
    public class ListBoxTest : IEnumerable
    {

        public static void PrintArray(object[] theArray)
        {
            foreach (object obj in theArray)
            {
                Console.WriteLine("Value: {0}", obj);
            }
            Console.WriteLine("\n");
        }                 

        private class ListBoxEnumerator : IEnumerator
        {
            public ListBoxEnumerator(ListBoxTest lbt)
            {
                this.lbt = lbt;
                index = -1;
            }

            public object Current
            {
                get { return lbt[index]; }
            }

            public bool MoveNext()
            {
                index++;
                if (index >= lbt.strings.Length)
                    return false;
                else
                    return true;
            }

            public void Reset()
            {
                index = -1;
            }

            private ListBoxTest lbt;
            private int index;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)new ListBoxEnumerator(this);
        }
        
        // Khoi tao listbox voi chuoi
        public ListBoxTest(params string[] initStr)
        {
            strings = new String[10];
            // Copy tu mang chuoi tham so
            foreach (string s in initStr)
            {
                strings[ctr++] = s;
            }
        }

        public void Add(string theString)
        {
            strings[ctr] = theString;
            ctr++;
        }

        // Cho phep truy cap giong nhu mang
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= strings.Length)
                {
                    // sai      
                }
                return strings[index];
            }
            set
            {
                strings[index] = value;
            }
        }

        // Get so luong chuoi hien co
        public int GetNumEntries()
        {
            return ctr;
        }

        private string[] strings;
        private int ctr = 0;

        public class Tester
        {
            static void Main(string[] args)
            {
                ListBoxTest lbt = new ListBoxTest("Hello", "World");
                lbt.Add("What");
                lbt.Add("Is");
                lbt.Add("The");
                lbt.Add("C");
                lbt.Add("Sharp");
                string subst = "Universe";
                lbt[1] = subst;
                // tru cap tat ca cac chuoi
                int count = 1;
                foreach (string s in lbt)
                {
                    Console.WriteLine("Value {0}: {1}", count, s);
                    count++;
                }

                foreach (string s in lbt)
                {
                    Console.WriteLine("Value {0}: {1}", count, s);
                    count++;
                }

                Console.ReadLine();
            }
        }      
    }
}
