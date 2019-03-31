using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff;
            int month = 0;
            int year = 0;

            while(year <= 0)
            {
                Console.WriteLine("Please enter the year:");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease enter a valid year");
                }
            }

            while (month < 1 || month > 12)
            {
                Console.WriteLine("Please enter the month:");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease enter a valid month 1 - 12");
                }
            }


            myStaff = FileReader.GetStaff();
            for (int i = 0; i < myStaff.Count; i++)
            {


                try
                {
                    Console.WriteLine($"Please enter hours for {myStaff[i].NameOfStaff}:");
                    int hours = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].HoursWorked = hours;
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());

                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a number greater than 0");
                    i--;
                }
            }
            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.WriteLine("Payslips and summary generated.  Press any key to exit");
            Console.Read();
        }
    }
}
