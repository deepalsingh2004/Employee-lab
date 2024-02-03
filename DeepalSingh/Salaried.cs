using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepalSingh
{
    public class Salaried : Employee
    {
        public double Salary { get; set; }

        public Salaried() : base()
        {
        }
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary)
        : base(id, name, address, phone, sin, dob, dept)
        {
            Salary = salary;
        }

        public double GetPay()
        {
            return Salary;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nSalary: {Salary:C}";
        }
    }
}

