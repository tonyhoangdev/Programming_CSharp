using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap9_Array_Index_Collection
{
    public class ArrayList_ex
    {
        // Tao mot lop don gian de luu tru trong mang
        public class Employee : IComparable
        {
            public Employee(int empID)
            {
                this.empID = empID;
            }

            public override string ToString()
            {
                return empID.ToString();
            }

            public int EmpID
            {
                get
                {
                    return empID;
                }
                set
                {
                    empID = value;
                }
            }

            int empID;


            public int CompareTo(object obj)
            {
                Employee r = (Employee)obj;
                return this.empID.CompareTo(r.empID);
            }
        }

        public class Tester
        {
            static void Main(string[] args)
            {
                ArrayList empArray = new ArrayList();
                ArrayList intArray = new ArrayList();
                Random random = new Random();

                // Dua data vao mang
                for (int i = 0; i < 9; i++)
                {
                    empArray.Add(new Employee(random.Next(10) + 100));
                    intArray.Add(random.Next(10));
                }

                // In tat ca noi dung mang nguyen
                for (int i = 0; i < intArray.Count; i++)
                {
                    Console.Write("{0} ", intArray[i].ToString());
                }
                Console.WriteLine("\n");

                // in tat ca noi dung cua mang employee
                for (int i = 0; i < empArray.Count; i++)
                {
                    Console.Write("{0} ", empArray[i].ToString());
                }
                Console.WriteLine("\n");

                // Sap xep va hien thi mang nguyen
                intArray.Sort();
                // In tat ca noi dung mang nguyen
                for (int i = 0; i < intArray.Count; i++)
                {
                    Console.Write("{0} ", intArray[i].ToString());
                }
                Console.WriteLine("\n");

                // Sap xep va hien thi mang employee
                empArray.Sort();
                // in tat ca noi dung cua mang employee
                for (int i = 0; i < empArray.Count; i++)
                {
                    Console.Write("{0} ", empArray[i].ToString());
                }
                Console.WriteLine("\n");

                Console.WriteLine("empArray.Count: {0}", empArray.Count);
                Console.WriteLine("empArray.Capacity: {0}", empArray.Capacity);

                Console.ReadKey();
            }
        }


    }
}
