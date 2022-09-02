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

        public ProjectTeam()
        {
        }

        public override string ToString()
        {
            int teamSalary;

            if (Type.Equals("Full"))
            {
                teamSalary = programmers.FirstOrDefault().Salary;
                return "This is team number " + TeamNumber + ", our type is = " + Type + ", and we earn = " + teamSalary + ". Our team is made up" +
                    "by " + programmers.Count() + " programmers";
            }
            else if (Type.Equals("Half"))
            {
                teamSalary = programmers.FirstOrDefault().Salary / 2;
                return "This is team number " + TeamNumber + ", our type is = " + Type + ", and we earn = " + teamSalary + ". Our team is made up" +
                    "by " + programmers.Count() + " programmers";
            }
            else
            {
                teamSalary = programmers.FirstOrDefault().Salary;
                return "This is team number " + TeamNumber + ", our type is = " + Type + ", and we earn = " + teamSalary + ". Our team is made up" +
                    "by " + programmers.Count() + " programmers";
            }
        }
    }
}
