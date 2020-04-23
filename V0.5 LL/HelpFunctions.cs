using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace V0._5_LL
{
    class HelpFunctions
    {

        public static bool StudentListCheck(LinkedList<Student> studentlist)
        {
            if (studentlist.Count() == 0 || studentlist == null)
            {
                Console.WriteLine("There are no students!");
                return false;
            }
            return true;
        }
        public static bool DirectoryCheck(string path)
        {
            if (System.IO.File.Exists(path) == false)
            {
                Console.WriteLine("Wrong input / file doesn't exist. Please check your input.");
                return false;
            }
            return true;
        }
        public static void LstTofile(LinkedList<Student> studentlist, string towhere)
        {

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(towhere))
                {
                    string objstring = "";
                    for (int i = 0; i < studentlist.Count(); i++)
                    {
                        objstring = String.Format("{0} {1} {2} {3} {4}", studentlist.ElementAt(i).getName(), studentlist.ElementAt(i).getLastName(), studentlist.ElementAt(i).getAvrg(), studentlist.ElementAt(i).CalcFinal(), Environment.NewLine);
                        byte[] info = Encoding.ASCII.GetBytes(objstring);
                        fs.Write(info, 0, info.Length);
                    }
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void StudentGrouping(LinkedList<Student> studentlist)
        {
            //
            var timer = new Stopwatch();
            timer.Start();
            string printStr1 = "C:\\Users\\User\\Desktop\\notsofortunate.txt";
            string printStr2 = "C:\\Users\\User\\Desktop\\goodchaps.txt";
            /*if (DirectoryCheck("C:\\Users\\User\\Desktop\\") == false)
            {
                Console.WriteLine("Directory doesn't exist. Please check your input.");
                return;
            }*/
            LinkedList<Student> goodGroup = new LinkedList<Student>();
            LinkedList<Student> badGroup = new LinkedList<Student>();
            for (int i = 0; i < studentlist.Count(); i++)
            {
                if (studentlist.ElementAt(i).CalcFinal() < 5)
                {
                    badGroup.AddLast(studentlist.ElementAt(i));
                }

                if (studentlist.ElementAt(i).CalcFinal() >= 5)
                {
                    goodGroup.AddLast(studentlist.ElementAt(i));
                }

            }
            LstTofile(badGroup, printStr1);
            LstTofile(goodGroup, printStr2);
            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
        }
       
        public static LinkedList<Student> Readfiledata(string fileName)
        {
            var timer = new Stopwatch();
            timer.Start();
            LinkedList<Student> studentList = new LinkedList<Student>();
			if (DirectoryCheck(fileName) == false)
            {
                Console.WriteLine("Directory doesn't exist. Please check your input.");
                return null;
            }
            using (StreamReader sr = File.OpenText(fileName))
            {

                Student tempstudent = new Student();
                LinkedList<double> ingrades = new LinkedList<double>();
                char[] whitespace = new char[] { ' ', '\t' };
                //List<string> ssizes = new List<string>()
                string s = String.Empty;

                while ((s = sr.ReadLine()) != null)
                {
                    List<string> ssizes = new List<string>(s.Split(whitespace));
                    for (int i = 2; i < ssizes.Count() - 3; i++)
                    {
                        ingrades.AddLast(Convert.ToDouble(ssizes[i]));
                    }
                    tempstudent.AddStudentDetails(ssizes[0], ssizes[1], ingrades, Convert.ToDouble(ssizes[ssizes.Count() - 2]));
                    studentList.AddLast(tempstudent);
                    tempstudent = new Student();
                    ingrades.Clear();
                }
            }
            {
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                Console.WriteLine(foo);
            }
            return studentList;
        }
        public static Student CreateStudent(int index)
        {
            Student tempstudent = new Student();
            LinkedList<double> ingrades = new LinkedList<double>();
            double inexam;
            string inname = "vardas" + index;
            string inlastname = "pavarde" + index;             //check if user wants random grades
            var rand = new Random();
            for (int z = 0; z < rand.Next(1, 7); z++)
            {
                ingrades.AddLast(rand.Next(1, 11));
            }
            inexam = rand.Next(1, 11);
            tempstudent.AddStudentDetails(inname, inlastname, ingrades, inexam); //creates temp student to add to studentlist
            return tempstudent;

        }
        public static void GenerateFile(string givenpath, double studentcount)
        {
            var timer = new Stopwatch();
            timer.Start();
            var rand = new Random();
            string name = "Vardas";
            string lastname = "Pavarde";
            double grade1, grade2, grade3, grade4, grade5, grade6, gradeE;

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(givenpath))
                {
                    for (int i = 0; i < studentcount; i++)
                    {
                        name += "" + i;
                        lastname += "" + i;
                        grade1 = rand.Next(1, 11);
                        grade2 = rand.Next(1, 11);
                        grade3 = rand.Next(1, 11);
                        grade4 = rand.Next(1, 11);
                        grade5 = rand.Next(1, 11);
                        grade6 = rand.Next(1, 11);
                        gradeE = rand.Next(1, 11);
                        string tempstudent = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", name, lastname, grade1, grade2, grade3, grade4, grade5, grade6, gradeE, Environment.NewLine);
                        byte[] info = Encoding.ASCII.GetBytes(tempstudent);
                        fs.Write(info, 0, info.Length);

                        name = "Vardas";
                        lastname = "Pavarde";

                    }
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
        }
    }
}
