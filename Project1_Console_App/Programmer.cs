using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Console_App
{
    internal class Programmer : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public Activity Activity { get; set; }

        public Programmer(string firstName, string lastName, int salary, Activity activity)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Activity = activity;
        }

        public override string ToString()
        {
            return LastName + ", " + FirstName + ", " + "salary = " + Salary + "$.";
        }

        public void salaryCalculation()
        {
            
        }
    }


}
