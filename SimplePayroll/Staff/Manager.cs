using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayroll
{
    class Manager : Staff
    {

        private const float managerHourlyRate = 50;
        public float Allowance { get; set; }


        public Manager(string name) : base(name,managerHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;

            if(HoursWorked > 160)
            {
                TotalPay = BasicPay + Allowance;
            }
        }

        public override string ToString()
        {
            return $" Manager Name: {NameOfStaff} \n Rate: ${managerHourlyRate} \n HoursWorked: { HoursWorked}" +
                $"\n BasicPay: ${BasicPay} \n Allowance: ${Allowance} \n TotalPay: ${TotalPay}";
        }


    }
}
