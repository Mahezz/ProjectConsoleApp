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
        private const string xmlFile = "./data.xml";

        static void Main(string[] args)
        {
            //IT Company data loaded and initialised
            List<ProjectTeam> teams = loadSystem();
            //IT Company data updated
            updateSystem();
            //IT Company data saved and finally reported
            reportSystem(teams);
        }

        public static List<ProjectTeam> loadSystem()
        {

            List<Programmer> programmersFirstTeam = new List<Programmer>();
            List<Programmer> programmersSecondTeam = new List<Programmer>();
            ProjectTeam team1 = null;
            ProjectTeam team2 = null;
            Activity activity1 = null;
            Activity activity2 = null;
            XmlDocument document = new XmlDocument();

            try
            {
                if (File.Exists(xmlFile))
                {
                    Console.WriteLine("Document found. Data is loading...");
                    document.Load(xmlFile);

                }
                else
                {
                    Console.WriteLine("The document doesn´t exist. Generating XML file...");
                    try
                    {
                        createXML();
                        Console.WriteLine("XML file created with success. Data is loading...");
                        document.Load(xmlFile);
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
                                                    else if (item5.FirstChild.ParentNode.Name.Equals("activity"))
                                                    {
                                                        if (item5.FirstChild.HasChildNodes)
                                                        {
                                                            string activityName = "";
                                                            int dayStart = 0;
                                                            int dayFinish = 0;
                                                            int workedDays = 0;
                                                            int duration = 0;

                                                            foreach (XmlNode item6 in item5)
                                                            {
                                                                if (item6.FirstChild.ParentNode.Name.Equals("activityname"))
                                                                {
                                                                    activityName = item6.InnerText;
                                                                }
                                                                else if (item6.FirstChild.ParentNode.Name.Equals("daystart"))
                                                                {
                                                                    dayStart = Int32.Parse(item6.FirstChild.InnerText);
                                                                }
                                                                else if (item6.FirstChild.ParentNode.Name.Equals("dayfinish"))
                                                                {
                                                                    dayFinish = Int32.Parse(item6.FirstChild.InnerText);
                                                                }
                                                                else if (item6.FirstChild.ParentNode.Name.Equals("workeddays"))
                                                                {
                                                                    workedDays = Int32.Parse(item6.FirstChild.InnerText);
                                                                }
                                                                else if (item6.FirstChild.ParentNode.Name.Equals("duration"))
                                                                {
                                                                    duration = Int32.Parse(item6.FirstChild.InnerText);
                                                                }
                                                            }
                                                            activity1 = new Activity(activityName, dayStart, dayFinish, workedDays, duration);
                                                        }
                                                    }
                                                }
                                            }

                                            Programmer programmer = new Programmer(firstname, lastname, salary, activity1);
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

                                                    else if (item5.FirstChild.ParentNode.Name.Equals("activity"))
                                                    {
                                                        if (item5.FirstChild.HasChildNodes)
                                                        {
                                                            string activityname = "";
                                                            int daystart = 0;
                                                            int dayfinish = 0;
                                                            int workeddays = 0;
                                                            int duration = 0;

                                                            foreach (XmlNode item6 in item5)
                                                            {
                                                                if (item6.FirstChild.ParentNode.Name.Equals("activityname"))
                                                                {
                                                                    activityname = item6.InnerText;
                                                                }
                                                                else if (item6.FirstChild.ParentNode.Name.Equals("daystart"))
                                                                {
                                                                    daystart = Int32.Parse(item6.FirstChild.InnerText);
                                                                }
                                                                else if (item6.FirstChild.ParentNode.Name.Equals("dayfinish"))
                                                                {
                                                                    dayfinish = Int32.Parse(item6.FirstChild.InnerText);
                                                                }
                                                                else if (item6.FirstChild.ParentNode.Name.Equals("workeddays"))
                                                                {
                                                                    workeddays = Int32.Parse(item6.FirstChild.InnerText);
                                                                }
                                                                else if (item6.FirstChild.ParentNode.Name.Equals("duration"))
                                                                {
                                                                    duration = Int32.Parse(item6.FirstChild.InnerText);
                                                                }
                                                            }
                                                            activity2 = new Activity(activityname, daystart, dayfinish, workeddays, duration);
                                                        }
                                                    }
                                                }
                                            }

                                            Programmer programmer = new Programmer(firstname, lastname, salary, activity2);
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
            ProjectTeam pjTeam1 = new ProjectTeam("Full", 1);
            ProjectTeam pjTeam2 = new ProjectTeam("Half", 2);
            Activity activity1 = new Activity("Activity 1", 1, 10, 3, 9);
            Activity activity2 = new Activity("Activity 2", 4, 12, 5, 8);

            Programmer p1 = new Programmer("Angel", "Torres", pjTeam1.SalaryCalculation(pjTeam1.Type), activity1);
            Programmer p2 = new Programmer("Pablo", "Turiel", pjTeam1.SalaryCalculation(pjTeam1.Type), activity1);
            Programmer p3 = new Programmer("Lucas", "Cuestarriba", pjTeam2.SalaryCalculation(pjTeam2.Type), activity2);
            Programmer p4 = new Programmer("Julian", "Rajoz", pjTeam2.SalaryCalculation(pjTeam2.Type), activity2);

            List<Programmer> team1 = new List<Programmer>(){
                p1,p2
            };
            List<Programmer> team2 = new List<Programmer>(){
                p3,p4
            };

            pjTeam1.programmers = team1;
            pjTeam2.programmers = team2;



            XmlDocument document = new XmlDocument();

            XmlDeclaration xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);

            XmlElement raiz = document.DocumentElement;
            document.InsertBefore(xmlDeclaration, raiz);

            XmlElement projectTeams = document.CreateElement(string.Empty, "teams", string.Empty);
            document.AppendChild(projectTeams);

            //First team creation

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

            //Activity - Programmer 1

            XmlElement programmerActivity = document.CreateElement(string.Empty, "activity", string.Empty);
            XmlElement programmerActivityName = document.CreateElement(string.Empty, "activityname", string.Empty);
            XmlText textActivityName = document.CreateTextNode(pjTeam1.programmers[0].Activity.ActivityName);
            programmer.AppendChild(programmerActivity);
            programmerActivity.AppendChild(programmerActivityName);
            programmerActivityName.AppendChild(textActivityName);

            XmlElement programmerActivityDayS = document.CreateElement(string.Empty, "daystart", string.Empty);
            XmlText textActivityDayS = document.CreateTextNode(pjTeam1.programmers[0].Activity.DayStart.ToString());
            programmerActivity.AppendChild(programmerActivityDayS);
            programmerActivityDayS.AppendChild(textActivityDayS);

            XmlElement programmerActivityDayF = document.CreateElement(string.Empty, "dayfinish", string.Empty);
            XmlText textActivityDayF = document.CreateTextNode(pjTeam1.programmers[0].Activity.DayFinish.ToString());
            programmerActivity.AppendChild(programmerActivityDayF);
            programmerActivityDayF.AppendChild(textActivityDayF);

            XmlElement programmerActivityWorkedDays = document.CreateElement(string.Empty, "workeddays", string.Empty);
            XmlText textActivityWorkedDays = document.CreateTextNode(pjTeam1.programmers[0].Activity.WorkedDays.ToString());
            programmerActivity.AppendChild(programmerActivityWorkedDays);
            programmerActivityWorkedDays.AppendChild(textActivityWorkedDays);

            XmlElement programmerActivityDuration = document.CreateElement(string.Empty, "duration", string.Empty);
            XmlText textActivityDuration = document.CreateTextNode(pjTeam1.programmers[0].Activity.Duration.ToString());
            programmerActivity.AppendChild(programmerActivityDuration);
            programmerActivityDuration.AppendChild(textActivityDuration);



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

            //Activity - Programmer 2

            XmlElement programmerActivity2 = document.CreateElement(string.Empty, "activity", string.Empty);
            XmlElement programmerActivityName2 = document.CreateElement(string.Empty, "activityname", string.Empty);
            XmlText textActivityName2 = document.CreateTextNode(pjTeam1.programmers[1].Activity.ActivityName);
            programmer2.AppendChild(programmerActivity2);
            programmerActivity2.AppendChild(programmerActivityName2);
            programmerActivityName2.AppendChild(textActivityName2);

            XmlElement programmerActivityDayS2 = document.CreateElement(string.Empty, "daystart", string.Empty);
            XmlText textActivityDayS2 = document.CreateTextNode(pjTeam1.programmers[1].Activity.DayStart.ToString());
            programmerActivity2.AppendChild(programmerActivityDayS2);
            programmerActivityDayS2.AppendChild(textActivityDayS2);

            XmlElement programmerActivityDayF2 = document.CreateElement(string.Empty, "dayfinish", string.Empty);
            XmlText textActivityDayF2 = document.CreateTextNode(pjTeam1.programmers[1].Activity.DayFinish.ToString());
            programmerActivity2.AppendChild(programmerActivityDayF2);
            programmerActivityDayF2.AppendChild(textActivityDayF2);

            XmlElement programmerActivityWorkedDays2 = document.CreateElement(string.Empty, "workeddays", string.Empty);
            XmlText textActivityWorkedDays2 = document.CreateTextNode(pjTeam1.programmers[1].Activity.WorkedDays.ToString());
            programmerActivity2.AppendChild(programmerActivityWorkedDays2);
            programmerActivityWorkedDays2.AppendChild(textActivityWorkedDays2);

            XmlElement programmerActivityDuration2 = document.CreateElement(string.Empty, "duration", string.Empty);
            XmlText textActivityDuration2 = document.CreateTextNode(pjTeam1.programmers[1].Activity.Duration.ToString());
            programmerActivity2.AppendChild(programmerActivityDuration2);
            programmerActivityDuration2.AppendChild(textActivityDuration2);

            projectTeam.AppendChild(programmers);
            programmers.AppendChild(programmer);
            programmers.AppendChild(programmer2);

            //Second team creation

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

            //Activity - Programmer 3

            XmlElement programmerActivity3 = document.CreateElement(string.Empty, "activity", string.Empty);
            XmlElement programmerActivityName3 = document.CreateElement(string.Empty, "activityname", string.Empty);
            XmlText textActivityName3 = document.CreateTextNode(pjTeam2.programmers[0].Activity.ActivityName);
            programmer3.AppendChild(programmerActivity3);
            programmerActivity3.AppendChild(programmerActivityName3);
            programmerActivityName3.AppendChild(textActivityName3);

            XmlElement programmerActivityDayS3 = document.CreateElement(string.Empty, "daystart", string.Empty);
            XmlText textActivityDayS3 = document.CreateTextNode(pjTeam2.programmers[0].Activity.DayStart.ToString());
            programmerActivity3.AppendChild(programmerActivityDayS3);
            programmerActivityDayS3.AppendChild(textActivityDayS3);

            XmlElement programmerActivityDayF3 = document.CreateElement(string.Empty, "dayfinish", string.Empty);
            XmlText textActivityDayF3 = document.CreateTextNode(pjTeam2.programmers[0].Activity.DayFinish.ToString());
            programmerActivity3.AppendChild(programmerActivityDayF3);
            programmerActivityDayF3.AppendChild(textActivityDayF3);

            XmlElement programmerActivityWorkedDays3 = document.CreateElement(string.Empty, "workeddays", string.Empty);
            XmlText textActivityWorkedDays3 = document.CreateTextNode(pjTeam2.programmers[0].Activity.WorkedDays.ToString());
            programmerActivity3.AppendChild(programmerActivityWorkedDays3);
            programmerActivityWorkedDays3.AppendChild(textActivityWorkedDays3);

            XmlElement programmerActivityDuration3 = document.CreateElement(string.Empty, "duration", string.Empty);
            XmlText textActivityDuration3 = document.CreateTextNode(pjTeam2.programmers[0].Activity.Duration.ToString());
            programmerActivity3.AppendChild(programmerActivityDuration3);
            programmerActivityDuration3.AppendChild(textActivityDuration3);

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

            //Activity - Programmer 4

            XmlElement programmerActivity4 = document.CreateElement(string.Empty, "activity", string.Empty);
            XmlElement programmerActivityName4 = document.CreateElement(string.Empty, "activityname", string.Empty);
            XmlText textActivityName4 = document.CreateTextNode(pjTeam2.programmers[1].Activity.ActivityName);
            programmer4.AppendChild(programmerActivity4);
            programmerActivity4.AppendChild(programmerActivityName4);
            programmerActivityName4.AppendChild(textActivityName4);

            XmlElement programmerActivityDayS4 = document.CreateElement(string.Empty, "daystart", string.Empty);
            XmlText textActivityDayS4 = document.CreateTextNode(pjTeam2.programmers[1].Activity.DayStart.ToString());
            programmerActivity4.AppendChild(programmerActivityDayS4);
            programmerActivityDayS4.AppendChild(textActivityDayS4);

            XmlElement programmerActivityDayF4 = document.CreateElement(string.Empty, "dayfinish", string.Empty);
            XmlText textActivityDayF4 = document.CreateTextNode(pjTeam2.programmers[1].Activity.DayFinish.ToString());
            programmerActivity4.AppendChild(programmerActivityDayF4);
            programmerActivityDayF4.AppendChild(textActivityDayF4);

            XmlElement programmerActivityWorkedDays4 = document.CreateElement(string.Empty, "workeddays", string.Empty);
            XmlText textActivityWorkedDays4 = document.CreateTextNode(pjTeam2.programmers[1].Activity.WorkedDays.ToString());
            programmerActivity4.AppendChild(programmerActivityWorkedDays4);
            programmerActivityWorkedDays4.AppendChild(textActivityWorkedDays4);

            XmlElement programmerActivityDuration4 = document.CreateElement(string.Empty, "duration", string.Empty);
            XmlText textActivityDuration4 = document.CreateTextNode(pjTeam2.programmers[1].Activity.Duration.ToString());
            programmerActivity4.AppendChild(programmerActivityDuration4);
            programmerActivityDuration4.AppendChild(textActivityDuration4);


            projectTeam2.AppendChild(programmers2);
            programmers2.AppendChild(programmer3);
            programmers2.AppendChild(programmer4);


            //Document saved
            document.Save("./data.xml");
        }

        public static void updateSystem()
        {

            //Open file
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);

            //Select activity nodes for updating "duration" of programmers
            XmlNodeList activities = doc.SelectNodes("//teams/team/programmers/programmer/activity");
            Console.WriteLine("Increasing the duration of all programmers in charge (+1 day)...");

            //If we have to update "duration", we will also have to update "dayfinish" value
            foreach (XmlNode activity in activities)
            {
                XmlNode duration = activity.SelectSingleNode("duration");
                int durationUpdated = Int32.Parse(duration.InnerText) + 1;
                duration.InnerText = durationUpdated.ToString();

                XmlNode dayfinish = activity.SelectSingleNode("dayfinish");
                int dayfinishUpdated = Int32.Parse(dayfinish.InnerText) + 1;
                dayfinish.InnerText = dayfinishUpdated.ToString();
            }


            //Document saved
            doc.Save(xmlFile);
            Console.WriteLine("Data has been updated and saved.");

        }

        public static void reportSystem(List<ProjectTeam> teams)
        {
            List<Programmer> programmers = new List<Programmer>()
            {
                teams[0].programmers[0], teams[0].programmers[1],
                teams[1].programmers[0], teams[1].programmers[1]
            };

            int remainingDaysT1 = teams[0].programmers[0].Activity.Duration - teams[0].programmers[0].Activity.WorkedDays;
            int remainingDaysT2 = teams[1].programmers[0].Activity.Duration - teams[1].programmers[0].Activity.WorkedDays;


            int daysConsummed = teams[0].programmers[0].Activity.WorkedDays + teams[1].programmers[0].Activity.WorkedDays;
            int remainingDays = remainingDaysT1 + remainingDaysT2;

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("IT COMPANY - REPORT");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("IT Company is actually composed of " + teams.Count() + " teams, and "
                + programmers.Count() + " programmers.");
            Console.WriteLine("This month, " + daysConsummed + " days have been" +
                "consumed by " + programmers.Count + " programmers, and " + remainingDays + " days still in charge.");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("Project teams details");
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (ProjectTeam team in teams)
            {

                Console.WriteLine("Project team: " + team.TeamNumber);

                foreach (Programmer programmer in team.programmers)
                { 
                    Console.WriteLine(programmer.ToString());
                }
            }


        }
    }
}