using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V0._4
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
}
