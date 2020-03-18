using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Student
    {
        string name = string.Empty;
        string lastname = string.Empty;
        List<double> grades = new List<double>();
        double exam = 0;
        double avrg = 0;
        double med = 0;

        public void GetStudentDetails(string inname, string inlastname, List<double> ingrades, double inexam)
        {
            name = inname;
            lastname = inlastname;
            grades = ingrades;
            exam = inexam;
            avrg=CalcAvrg(grades);
            med = CalcMed(grades);
        }
        public double CalcAvrg(List<double> grades)
        {
            return grades.Average();
        }
        public double CalcMed(List<double> grades)
        {
            return (grades.Count-1)/2;
        }
        public void PrintToConsoleStudentDetails()
        {
            Console.WriteLine(name);
            Console.WriteLine(lastname);
            Console.WriteLine(exam);
        }
        public void PrintToConsoleStudentAverage()
        {
            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,5}", name, lastname, avrg));
        }
        public void PrintToConsoleStudentMediana()
        {
            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,5}", name, lastname, med));
        }
    }
    class Program
    {
        static List<Student> allstudents = new List<Student>();
      
        public static void EnterStudents(int studentcount)
        {
            Student tempstudent = new Student();
            string inname, inlastname;
            List<double> ingrades = new List<double>();
            List<double> randgrades = new List<double>();
            double inexam = 0;
            string inp = "";
            string ifrnd = "";
            var rand = new Random();

            for (int i = 0; i < studentcount; i++)
            {
                Console.WriteLine("enter name");
                inname = Console.ReadLine();
                Console.WriteLine("enter lastname");
                inlastname = Console.ReadLine();
                Console.WriteLine("are you want to generate random homework and exam grades? y/n ");
                ifrnd = Console.ReadLine();
                if (ifrnd == "y")
                {
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
                    Console.WriteLine("enter exam");
                    inexam = Convert.ToDouble(Console.ReadLine());
                }
                tempstudent.GetStudentDetails(inname, inlastname, ingrades, inexam);
                Program.allstudents.Add(tempstudent);
                tempstudent = new Student();
                ingrades.Clear();
            }

        }
        public static void MENU()
        {
            string flag = " ";
            string caseSwitch = "";
            while (flag != "TERMINATE")
            {
                Console.WriteLine("1 - enter new students");
                Console.WriteLine("2 - get student list with averages");
                Console.WriteLine("3 - get student list with mediana");
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
                        Console.WriteLine("Vardas     Pavardė        Galutinis(Vid.)");
                        Console.WriteLine("-----------------------------------------");
                        for (int i = 0; i < allstudents.Count(); i++)
                        {                          
                            allstudents[i].PrintToConsoleStudentAverage();
                        }
                        
                        break;
                    case "3":
                        Console.WriteLine("Vardas     Pavardė        Galutinis(Med.)");
                        Console.WriteLine("-----------------------------------------");
                        for (int i = 0; i < allstudents.Count(); i++)
                        {
                            allstudents[i].PrintToConsoleStudentMediana();
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
