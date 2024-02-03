using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepalSingh
{
    public class PartTime : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }

        public PartTime() : base()
        {

        }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        : base(id, name, address, phone, sin, dob, dept)
        {
            Rate = rate;
            Hours = hours;
        }
        public double GetPay()
        {
            return Rate * Hours;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nHourly Rate: {Rate:C}\nHours Worked: {Hours}";
        }
    }
}
