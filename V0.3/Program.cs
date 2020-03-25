using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V0_3
{
    class Student
    {
        private string name;
        private string lastname;
        private List<double> grades;
        private double exam;
        private double avrg = 0;
        private double med = 0;

        public void GetStudentDetail(string name, string lastname, List<double> grades, double exam, double avrg, double med)
        {
            this.name = name;
            this.lastname = lastname;
            this.grades = grades;
            this.exam = exam;
            this.avrg = avrg;
            this.med = med;
        }

        public string getName()
        { return name; }

        public string getLastName()
        { return lastname; }

        public void SetStudentDetail(string inname, string inlastName, List<double> ingrades, double inexam)
        {
            this.name = inname;
            this.lastname = inlastName;
            this.grades = ingrades;
            this.exam = inexam;
            this.avrg = CalcAvrg(grades);
            this.med = CalcMed(grades);
        }


        //string name = string.Empty;
        //string lastname = string.Empty;
        //List<double> grades = new List<double>();
        //double exam = 0;



        // finds average of all grades (except exam)
        public double CalcAvrg(List<double> grades)
        {
            return grades.Average();
        }
        // finds mediana of all grades (except exam)
        public double CalcMed(List<double> grades)
        {
            return (grades.Count - 1) / 2;
        }

        public void AddStudentDetails(string inname, string inlastname, List<double> ingrades, double inexam)
        {
            name = inname;
            lastname = inlastname;
            grades = ingrades;
            exam = inexam;
            avrg = CalcAvrg(grades);
            med = CalcMed(grades);
        }

        //created for testing output data
        public void PrintToConsoleStudentDetails()
        {
            Console.WriteLine(name);
            Console.WriteLine(lastname);
            Console.WriteLine(exam);
        }
        //method for printing grade averages
        public void PrintToConsoleStudentAverage()
        {
            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,5:.##}", name, lastname, avrg));
        }
        //method for printing grade mediana
        public void PrintToConsoleStudentMediana()
        {
            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,5:.##}", name, lastname, med));
        }
        public void PrintToConsoleStudentBoth()
        {
            Console.WriteLine(String.Format("{0,-10} {1,-10} {2,15} {3,20:.##}", name, lastname, avrg, med));
        }
    }
    class Program
    {
        // holds all the students that were created
        static List<Student> allstudents = new List<Student>();

        //method 
        public static void EnterStudents(int studentcount)
        {
            Student tempstudent = new Student();
            string inname, inlastname;
            List<double> ingrades = new List<double>();
            double inexam = 0;
            string inp = "";
            string ifrnd = "";             //check if user wants random grades
            var rand = new Random();
            //bool result;
            for (int i = 0; i < studentcount; i++)
            {
                Console.WriteLine("Enter name");
                inname = Console.ReadLine();
                Console.WriteLine("Enter lastname");
                inlastname = Console.ReadLine();
                Console.WriteLine("Are you want to generate random homework and exam grades? y/n ");
                Ifrndchoice:
                ifrnd = Console.ReadLine();
                try
                {
                    if (ifrnd == "y")
                    {
                        // random grades are set to 100 to avoid overload
                        for (int z = 0; z < rand.Next(1, 100); z++)
                        {
                            ingrades.Add(rand.Next(1, 11));
                        }
                        inexam = rand.Next(1, 11);
                    }
                    else
                    {
                        Console.WriteLine("enter grades, to stop type '-t' ");
                        while (inp != "-t")
                        {
                            inp = Console.ReadLine();
                            if (inp == "-t")
                                break;

                            else { ingrades.Add(Convert.ToDouble(inp)); }
                        }
                        Console.WriteLine("enter exam grade");
                        inexam = Convert.ToDouble(Console.ReadLine());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wrong input! *user input error*");
                    goto Ifrndchoice; 
                }
                tempstudent.AddStudentDetails(inname, inlastname, ingrades, inexam); //creates temp student to add to studentlist
                Program.allstudents.Add(tempstudent); //adds student to the list
                //clearing info
                tempstudent = new Student();
                ingrades.Clear();
            }

        }
        public static void ReadFile()
        {

            Student tempstudent = new Student();
            string inname, inlastname;
            List<double> ingrades = new List<double>();
            double inexam = 0;
            string textFile = "";
            Console.WriteLine("enter file directory");

            //string textFile = "C:\\Users\\User\\Desktop\\kursiokai.txt";
            Direnter:
                textFile = Console.ReadLine();
            if (System.IO.File.Exists(textFile) == false)
            {
                Console.WriteLine("Wrong input / file doesn't exist. Please try again.");
                goto Direnter;
            }
            
            string[] lines = System.IO.File.ReadAllLines(textFile);
            foreach (string line in lines.Skip(1))
            {
                char[] whitespace = new char[] { ' ', '\t' };
                List<string> ssizes = new List<string>(line.Split(whitespace));
                if (ssizes == null || ssizes.Count == 0)
                {
                    Console.WriteLine("File is empty");
                    break;
                }
                    inname = ssizes[0];
                inlastname = ssizes[1];
                for (int i = 2; i < ssizes.Count() - 2; i++)
                {
                    LoopStart:
                    try
                    {
                        ingrades.Add(Convert.ToDouble(ssizes[i]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Wrong input! *read file error*" );
                        goto LoopStart;
                    }

                }
                inexam = Convert.ToDouble(ssizes[ssizes.Count() - 1]);
                tempstudent.AddStudentDetails(inname, inlastname, ingrades, inexam);
                Program.allstudents.Add(tempstudent);
                tempstudent = new Student();
                ingrades.Clear();
            }



        }
        public static void FilePrintOut()
        {
            allstudents.Sort(delegate (Student p1, Student p2)
            {
                int result = p1.getName().CompareTo(p2.getName());
                if (result == 0)
                    result = p1.getLastName().CompareTo(p2.getLastName());
                return result;
            });
            Console.WriteLine(String.Format("{0,-10} {1,-10} {2,15} {3,20:.##}", "Vardas", "Pavarde", "Galutinis(Vid.)/", "Galutinis(Med.)"));
            Console.WriteLine("-----------------------------------------------------------");
            for (int i = 0; i < allstudents.Count(); i++)
            {
                allstudents[i].PrintToConsoleStudentBoth();
            }
        }
        public static void MENU()
        {
            string flag = " ";
            string caseSwitch = "";
            while (flag != "TERMINATE")
            {
                Console.WriteLine("1 - enter new students");
                Console.WriteLine("2 - get students from file");
                Console.WriteLine("3 - get student list with averages");
                Console.WriteLine("4 - get student list with mediana");
                Console.WriteLine("TERMINATE - exit");
                caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        Console.WriteLine("enter student count ");
                        int studentcount = Convert.ToInt32(Console.ReadLine());
                        EnterStudents(studentcount);
                        break;
                    case "2":
                        ReadFile();
                        FilePrintOut();
                        break;
                    case "3":
                       
                        try
                        {
                            Console.WriteLine("Vardas     Pavardė        Galutinis(Vid.)");
                            Console.WriteLine("-----------------------------------------");
                            for (int i = 0; i < allstudents.Count(); i++)
                            {
                                allstudents[i].PrintToConsoleStudentAverage();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("There are no students!");
                        }
                        break;
                    case "4":
                        
                        try
                        {
                            Console.WriteLine("Vardas     Pavardė        Galutinis(Med.)");
                            Console.WriteLine("-----------------------------------------");
                            for (int i = 0; i < allstudents.Count(); i++)
                            {
                                allstudents[i].PrintToConsoleStudentMediana();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("There are no students!");
                        }
                        break;


                    case "TERMINATE":
                        flag = "TERMINATE";
                        return;
                    default:
                        break;
                }

            }
        }
        static void Main(string[] args)
        {

            MENU();

        }
    }
}
