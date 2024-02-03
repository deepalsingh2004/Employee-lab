using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepalSingh
{
   public class Employee
   {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Sin { get; set; }
        public string Dob { get; set; }
        public string Dept { get; set; }


        public Employee()
        {

        }

        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
        }


        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nAddress: {Address}\nPhone: {Phone}\nSIN: {Sin}\nDOB: {Dob}\nDept: {Dept}";
        }
   }
}

