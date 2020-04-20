using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace V0._4
{
    class HelpFunctions
    {
        public static List<Student> GetFileData(string filepath)
        {
            var timer = new Stopwatch();
            timer.Start();

            List<Student> studentList = new List<Student>();
            Student tempstudent = new Student();
            string inname, inlastname;
            List<double> ingrades = new List<double>();
            double inexam = 0;
            string textFile = "";
            textFile = filepath;
            if (System.IO.File.Exists(textFile) == false)
            {
                Console.WriteLine("Wrong input / file doesn't exist. Please check your input.");
                return null;
            }

            string[] lines = System.IO.File.ReadAllLines(textFile);
            foreach (string line in lines.Skip(1))
            {
                //clearing spaces dividing into strings
                char[] whitespace = new char[] { ' ', '\t' };
                List<string> ssizes = new List<string>(line.Split(whitespace));
                if (ssizes == null || ssizes.Count == 0)
                {
                    Console.WriteLine("File is empty");
                    break;
                }
                //assigning values
                inname = ssizes[0];
                inlastname = ssizes[1];

                for (int i = 2; i < ssizes.Count() - 2; i++)
                {
                    ingrades.Add(Convert.ToDouble(ssizes[i]));


                }
                try
                {
                    inexam = Convert.ToDouble(ssizes[ssizes.Count() - 1]);
                }
                catch
                {

                }
                tempstudent.AddStudentDetails(inname, inlastname, ingrades, inexam);
                studentList.Add(tempstudent);
                tempstudent = new Student();
                ingrades.Clear();
            }
            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
            return studentList;
        }
        public static Student CreateStudent(int index)
        {
            Student tempstudent = new Student();
            List<double> ingrades = new List<double>();
            double inexam;
            string inname = "vardas"+index;
            string inlastname = "pavarde" + index;             //check if user wants random grades
            var rand = new Random();
            for (int z = 0; z < rand.Next(1, 7); z++)
            {
                ingrades.Add(rand.Next(1, 11));
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
                        grade1 = rand.Next(1,11);
                        grade2 = rand.Next(1, 11);
                        grade3 = rand.Next(1, 11);
                        grade4 = rand.Next(1, 11);
                        grade5 = rand.Next(1, 11);
                        grade6 = rand.Next(1, 11);
                        gradeE = rand.Next(1, 11);
                        string tempstudent = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", name, lastname, grade1, grade2, grade3, grade4, grade5, grade6, gradeE, Environment.NewLine) ;
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
