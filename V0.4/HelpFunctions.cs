using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace V0._4
{
    class HelpFunctions
    {

        /*public static void Testingfunction()
        {
            //Console.WriteLine("say yellow");
        }*/
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
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

                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void Old_GenerateFile(string givenpath, double studentcount, string filename)
        {
            //string givenpath = @"c:\temp\MyTest.txt";
            Student tempstudent = new Student();
            var rand = new Random();
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(givenpath))
                {
                    for (int i = 0; i < studentcount; i++)
                    {
                        tempstudent=CreateStudent(i);
                        byte[] info = ObjectToByteArray(tempstudent);
                        fs.Write(info, 0, info.Length);

                    }
                    
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(givenpath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }
}
