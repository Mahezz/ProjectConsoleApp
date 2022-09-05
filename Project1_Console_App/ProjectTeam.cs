using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Console_App
{
    internal class ProjectTeam
    {
        public string Type { get; set; }
        public int TeamNumber { get; set; }

        public List<Programmer> programmers { get; set; }

        public ProjectTeam(string type, int teamNumber, List<Programmer> programmers)
        {
            Type = type;
            TeamNumber = teamNumber;
            this.programmers = programmers;
        }

        public ProjectTeam(string type, int teamNumber)
        {
            Type = type;
            TeamNumber = teamNumber;
        }

        public ProjectTeam()
        {
        }


        //In this class is where we calculate the salary of the programmers as here is where the
        //"type" attribute is identified. Teams with "type" = "half" -> 50% = totalSalary/2
        public int SalaryCalculation(string type)
        {
            const int EMPLOYEE_SALARY_PER_DAY = 145;
            int salary = 0;

            if (type.Equals("Half"))
            {
                salary = EMPLOYEE_SALARY_PER_DAY/2;
            }
            else if(type.Equals("Full"))
            {
                salary = EMPLOYEE_SALARY_PER_DAY;
            }

            return salary;
        }

    }
}
