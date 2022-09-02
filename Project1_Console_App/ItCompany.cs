using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Project1_Console_App
{
    internal class ItCompany
    {
        private const int EMPLOYEE_SALARY = 1200;
        const string xmlFile = "./data.xml";

        static void Main(string[] args)
        {
            #region first
            //Programmer p1 = new Programmer("Angel", "Torres", EMPLOYEE_SALARY, pjTeam1);
            //Programmer p2 = new Programmer("Pablo", "Turiel", EMPLOYEE_SALARY, pjTeam1);
            //Programmer p3 = new Programmer("Lucas", "Cuestarriba", EMPLOYEE_SALARY, pjTeam2);
            //Programmer p4 = new Programmer("Julian", "Rajoz", EMPLOYEE_SALARY, pjTeam2);

            //Programmer p1 = new Programmer("Angel", "Torres", EMPLOYEE_SALARY);
            //Programmer p2 = new Programmer("Pablo", "Turiel", EMPLOYEE_SALARY);
            //Programmer p3 = new Programmer("Lucas", "Cuestarriba", EMPLOYEE_SALARY);
            //Programmer p4 = new Programmer("Julian", "Rajoz", EMPLOYEE_SALARY);

            //List<Programmer> team1 = new List<Programmer>(){
            //    p1,p2
            //};
            //List<Programmer> team2 = new List<Programmer>(){
            //    p3,p4
            //};


            //List<Programmer> programmers = new List<Programmer>()
            //{
            //    p1,p2,p3,p4
            //};



            //ProjectTeam pjTeam1 = new ProjectTeam("Full", 1, team1);
            //ProjectTeam pjTeam2 = new ProjectTeam("Half", 2, team2);


            //List<ProjectTeam> teams = new List<ProjectTeam>()
            //{
            //    pjTeam1,pjTeam2
            //};


            //Console.WriteLine("IT COMPANY - REPORT");
            //Console.WriteLine("-----------------------------------------------------------------");
            //Console.WriteLine("IT Company is actually composed of " + teams.Count() + " teams, and "
            //    + programmers.Count() + " programmers.");

            //for (int i = 0; i < programmers.Count(); i++)
            //{
            //    Console.WriteLine(programmers[i].ToString());
            //}
            #endregion

            List<ProjectTeam> teams = loadXML();


        }

        public static List<ProjectTeam> loadXML()
        {

            List<Programmer> programmersFirstTeam = new List<Programmer>();
            List<Programmer> programmersSecondTeam = new List<Programmer>();
            ProjectTeam team1 = null;
            ProjectTeam team2 = null;
            XmlDocument document = new XmlDocument();

            try
            {
                if (File.Exists(xmlFile))
                {
                    document.Load(xmlFile);

                }
                else
                {
                    Console.WriteLine("The document doesn´t exist. Generating XML file...");
                    try
                    {
                        createXML();
                        Console.WriteLine("XML file created with success.");
                    }
                    catch (Exception ef)
                    {
                        Console.WriteLine(ef.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            int teamCount = 0;

            foreach (XmlNode item in document.ChildNodes)
            {
                if (item.HasChildNodes)
                {
                    foreach (XmlNode item2 in item.ChildNodes)
                    {
                        teamCount++;
                        if (teamCount == 1)
                        {
                            team1 = new ProjectTeam();

                            foreach (XmlNode item3 in item2.ChildNodes)
                            {
                                if (item3.FirstChild.ParentNode.Name.Equals("number"))
                                {
                                    team1.TeamNumber = Int32.Parse(item3.FirstChild.InnerText);
                                }
                                else if (item3.FirstChild.ParentNode.Name.Equals("type"))
                                {
                                    team1.Type = item3.FirstChild.InnerText;
                                }
                                else if (item3.FirstChild.ParentNode.Name.Equals("programmers"))
                                {

                                    if (item3.FirstChild.HasChildNodes)
                                    {
                                        string firstname = "";
                                        string lastname = "";
                                        int salary = 0;

                                        foreach (XmlNode item4 in item3.ChildNodes)
                                        {
                                            if (item4.HasChildNodes)
                                            {
                                                foreach (XmlNode item5 in item4.ChildNodes)
                                                {
                                                    if (item5.FirstChild.ParentNode.Name.Equals("firstname"))
                                                    {
                                                        firstname = item5.InnerText;
                                                    }
                                                    else if (item5.FirstChild.ParentNode.Name.Equals("lastname"))
                                                    {
                                                        lastname = item5.FirstChild.InnerText;
                                                    }
                                                    else if (item5.FirstChild.ParentNode.Name.Equals("salary"))
                                                    {
                                                        salary = Int32.Parse(item5.FirstChild.InnerText);
                                                    }
                                                }
                                            }

                                            Programmer programmer = new Programmer(firstname, lastname, salary);
                                            programmersFirstTeam.Add(programmer);
                                            //List
                                        }
                                    }
                                }
                            }

                            team1.programmers = programmersFirstTeam;
                        }
                        else if (teamCount == 2)
                        {
                            team2 = new ProjectTeam();

                            foreach (XmlNode item3 in item2.ChildNodes)
                            {
                                if (item3.FirstChild.ParentNode.Name.Equals("number"))
                                {
                                    team2.TeamNumber = Int32.Parse(item3.FirstChild.InnerText);
                                }
                                else if (item3.FirstChild.ParentNode.Name.Equals("type"))
                                {
                                    team2.Type = item3.FirstChild.InnerText;
                                }
                                else if (item3.FirstChild.ParentNode.Name.Equals("programmers"))
                                {

                                    if (item3.FirstChild.HasChildNodes)
                                    {
                                        string firstname = "";
                                        string lastname = "";
                                        int salary = 0;

                                        foreach (XmlNode item4 in item3.ChildNodes)
                                        {
                                            if (item4.HasChildNodes)
                                            {
                                                foreach (XmlNode item5 in item4.ChildNodes)
                                                {
                                                    if (item5.FirstChild.ParentNode.Name.Equals("firstname"))
                                                    {
                                                        firstname = item5.InnerText;
                                                    }
                                                    else if (item5.FirstChild.ParentNode.Name.Equals("lastname"))
                                                    {
                                                        lastname = item5.FirstChild.InnerText;
                                                    }
                                                    else if (item5.FirstChild.ParentNode.Name.Equals("salary"))
                                                    {
                                                        salary = Int32.Parse(item5.FirstChild.InnerText);
                                                    }
                                                }
                                            }

                                            Programmer programmer = new Programmer(firstname, lastname, salary);
                                            programmersSecondTeam.Add(programmer);
                                            //List
                                        }
                                    }
                                }
                            }

                            team2.programmers = programmersSecondTeam;
                        }
                    }
                }
            }

            List<ProjectTeam> teams = new List<ProjectTeam>()
            {
                team1,team2
            };

            return teams;
        }

        public static void createXML()
        {
            Programmer p1 = new Programmer("Angel", "Torres", EMPLOYEE_SALARY);
            Programmer p2 = new Programmer("Pablo", "Turiel", EMPLOYEE_SALARY);
            Programmer p3 = new Programmer("Lucas", "Cuestarriba", EMPLOYEE_SALARY);
            Programmer p4 = new Programmer("Julian", "Rajoz", EMPLOYEE_SALARY);

            List<Programmer> team1 = new List<Programmer>(){
                p1,p2
            };
            List<Programmer> team2 = new List<Programmer>(){
                p3,p4
            };

            var pjTeam1 = new ProjectTeam("Full", 1, team1);
            var pjTeam2 = new ProjectTeam("Half", 2, team2);



            XmlDocument document = new XmlDocument();

            XmlDeclaration xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);

            XmlElement raiz = document.DocumentElement;
            document.InsertBefore(xmlDeclaration, raiz);

            XmlElement projectTeams = document.CreateElement(string.Empty, "teams", string.Empty);
            document.AppendChild(projectTeams);

            XmlElement projectTeam = document.CreateElement(string.Empty, "team", string.Empty);
            projectTeams.AppendChild(projectTeam);

            XmlElement teamNumber = document.CreateElement(string.Empty, "number", string.Empty);
            XmlText textNumber = document.CreateTextNode(pjTeam1.TeamNumber.ToString());
            teamNumber.AppendChild(textNumber);
            projectTeam.AppendChild(teamNumber);

            XmlElement teamType = document.CreateElement(string.Empty, "type", string.Empty);
            XmlText textType = document.CreateTextNode(pjTeam1.Type);
            teamType.AppendChild(textType);
            projectTeam.AppendChild(teamType);

            XmlElement programmers = document.CreateElement(string.Empty, "programmers", string.Empty);
            XmlElement programmer = document.CreateElement(string.Empty, "programmer", string.Empty);

            XmlElement programmerFirstName = document.CreateElement(string.Empty, "firstname", string.Empty);
            XmlText textFirstName = document.CreateTextNode(pjTeam1.programmers[0].FirstName);
            programmer.AppendChild(programmerFirstName);
            programmerFirstName.AppendChild(textFirstName);

            XmlElement programmerLastName = document.CreateElement(string.Empty, "lastname", string.Empty);
            XmlText textLastName = document.CreateTextNode(pjTeam1.programmers[0].LastName);
            programmer.AppendChild(programmerLastName);
            programmerLastName.AppendChild(textLastName);

            XmlElement programmerSalary = document.CreateElement(string.Empty, "salary", string.Empty);
            XmlText textSalary = document.CreateTextNode(pjTeam1.programmers[0].Salary.ToString());
            programmer.AppendChild(programmerSalary);
            programmerSalary.AppendChild(textSalary);

            XmlElement programmer2 = document.CreateElement(string.Empty, "programmer", string.Empty);

            XmlElement programmerFirstName2 = document.CreateElement(string.Empty, "firstname", string.Empty);
            XmlText textFirstName2 = document.CreateTextNode(pjTeam1.programmers[1].FirstName);
            programmer2.AppendChild(programmerFirstName2);
            programmerFirstName2.AppendChild(textFirstName2);

            XmlElement programmerLastName2 = document.CreateElement(string.Empty, "lastname", string.Empty);
            XmlText textLastName2 = document.CreateTextNode(pjTeam1.programmers[1].LastName);
            programmer2.AppendChild(programmerLastName2);
            programmerLastName2.AppendChild(textLastName2);

            XmlElement programmerSalary2 = document.CreateElement(string.Empty, "salary", string.Empty);
            XmlText textSalary2 = document.CreateTextNode(pjTeam1.programmers[1].Salary.ToString());
            programmer2.AppendChild(programmerSalary2);
            programmerSalary2.AppendChild(textSalary2);


            projectTeam.AppendChild(programmers);
            programmers.AppendChild(programmer);
            programmers.AppendChild(programmer2);

            //SECOND TEAM

            XmlElement projectTeam2 = document.CreateElement(string.Empty, "team", string.Empty);
            projectTeams.AppendChild(projectTeam2);

            XmlElement teamNumber2 = document.CreateElement(string.Empty, "number", string.Empty);
            XmlText textNumber2 = document.CreateTextNode(pjTeam2.TeamNumber.ToString());
            teamNumber2.AppendChild(textNumber2);
            projectTeam2.AppendChild(teamNumber2);

            XmlElement teamType2 = document.CreateElement(string.Empty, "type", string.Empty);
            XmlText textType2 = document.CreateTextNode(pjTeam2.Type);
            teamType2.AppendChild(textType2);
            projectTeam2.AppendChild(teamType2);

            XmlElement programmers2 = document.CreateElement(string.Empty, "programmers", string.Empty);
            XmlElement programmer3 = document.CreateElement(string.Empty, "programmer", string.Empty);

            XmlElement programmer2FirstName = document.CreateElement(string.Empty, "firstname", string.Empty);
            XmlText text2FirstName = document.CreateTextNode(pjTeam2.programmers[0].FirstName);
            programmer3.AppendChild(programmer2FirstName);
            programmer2FirstName.AppendChild(text2FirstName);

            XmlElement programmer2LastName = document.CreateElement(string.Empty, "lastname", string.Empty);
            XmlText text2LastName = document.CreateTextNode(pjTeam2.programmers[0].LastName);
            programmer3.AppendChild(programmer2LastName);
            programmer2LastName.AppendChild(text2LastName);

            XmlElement programmer2Salary = document.CreateElement(string.Empty, "salary", string.Empty);
            XmlText text2Salary = document.CreateTextNode(pjTeam2.programmers[0].Salary.ToString());
            programmer3.AppendChild(programmer2Salary);
            programmer2Salary.AppendChild(text2Salary);

            XmlElement programmer4 = document.CreateElement(string.Empty, "programmer", string.Empty);

            XmlElement programmer4FirstName = document.CreateElement(string.Empty, "firstname", string.Empty);
            XmlText text4FirstName = document.CreateTextNode(pjTeam2.programmers[1].FirstName);
            programmer4.AppendChild(programmer4FirstName);
            programmer4FirstName.AppendChild(text4FirstName);

            XmlElement programmer4LastName = document.CreateElement(string.Empty, "lastname", string.Empty);
            XmlText textLast4Name2 = document.CreateTextNode(pjTeam2.programmers[1].LastName);
            programmer4.AppendChild(programmer4LastName);
            programmer4LastName.AppendChild(textLast4Name2);

            XmlElement programmer4Salary2 = document.CreateElement(string.Empty, "salary", string.Empty);
            XmlText text4Salary2 = document.CreateTextNode(pjTeam2.programmers[1].Salary.ToString());
            programmer4.AppendChild(programmer4Salary2);
            programmer4Salary2.AppendChild(text4Salary2);


            projectTeam2.AppendChild(programmers2);
            programmers2.AppendChild(programmer3);
            programmers2.AppendChild(programmer4);


            document.Save("./data.xml");
        }
    }
}