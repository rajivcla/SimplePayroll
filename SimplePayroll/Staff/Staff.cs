using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayroll
{
    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }


        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        public int HoursWorked {
            get
            {
                return hWorked;
            }
            set
            {
                if(value > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        }


        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return $"Name {NameOfStaff} TotalPay {TotalPay} BasicPay {BasicPay} HoursWorked {HoursWorked} rate {hourlyRate}";
        }
    }
}
