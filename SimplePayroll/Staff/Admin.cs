using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayroll
{
    class Admin : Staff
    {
        const float overTimeRate = 15.5f;
        const float adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if(HoursWorked > 160)
            {
                Overtime = (HoursWorked - 160) * (overTimeRate + adminHourlyRate);
                TotalPay = BasicPay +  Overtime;
            }
        }

        public override string ToString()
        {
            return $" Admin Name: {NameOfStaff} \n Rate: ${adminHourlyRate} \n HoursWorked: {HoursWorked}" +
                $"\n BasicPay:$ {BasicPay} \n Allowance: ${Overtime} \n TotalPay: ${TotalPay}";
        }

    }
}
