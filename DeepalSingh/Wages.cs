using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepalSingh
{
    public class Wages : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }
        public Wages() : base()
        {

        }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        : base(id, name, address, phone, sin, dob, dept)
        {
            Rate = rate;
            Hours = hours;
        }
        public double GetPay()
        {
            if (Hours <= 40)
            {
                return Rate * Hours;
            }
            else
            {
                return Rate * 40 + 1.5 * Rate * (Hours - 40);
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nHourly Rate: {Rate:C}\nHours Worked: {Hours}";
        }


    }
}
