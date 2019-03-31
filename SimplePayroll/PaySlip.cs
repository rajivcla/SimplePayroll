using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimplePayroll
{
    class PaySlip
    {
        private int month;
        private int year;

        private enum MonthsOfYear
        {
            JAN=1,
            FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach(Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("=============");
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine();
                    sw.WriteLine("Basic Pay: ${0}", f.BasicPay);
                    if (f.GetType() == typeof(Manager))
                    {
                        sw.WriteLine("Allowance: ${0}", ((Manager)f).Allowance);
                        sw.WriteLine();
                    }
                    else { 
                        sw.WriteLine("OverTime: ${0} \n", ((Admin)f).Overtime);
                        sw.WriteLine();
                    }
                    sw.WriteLine("=============");
                    sw.WriteLine("Total Pay: ${0}", f.TotalPay);
                    sw.WriteLine("=============");
                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result = myStaff.OrderBy(s => s.NameOfStaff).Where(s => s.HoursWorked < 10);
            string path = "summary.txt";
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("Name of Staff,Hours Worked");
                foreach (var f in result)
                {
                    sw.WriteLine($"{f.NameOfStaff},{f.HoursWorked}");
                }
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    
    }
}
