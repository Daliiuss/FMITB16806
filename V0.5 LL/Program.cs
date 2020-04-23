using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace V0._5_LL
{
    class InitializationException : Exception
    {
        string Message = "Error just happened";
    }
    class Program
    {
        // holds all the students that were created
        static LinkedList<Student> allstudents = new LinkedList<Student>();
        //static LinkedList<Student> linkedallstudents = new LinkedList<Student>();
        //static Queue<Student> queueallstudents = new Queue<Student>();

        //method 
        public static void EnterStudents(int studentcount)
        {
            var timer = new Stopwatch();
            timer.Start();
            Student tempstudent = new Student();
            string inname, inlastname;
            LinkedList<double> ingrades = new LinkedList<double>();
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
                            ingrades.AddLast(rand.Next(1, 11));
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

                            else { ingrades.AddLast(Convert.ToDouble(inp)); }
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
                Program.allstudents.AddLast(tempstudent); //adds student to the list
                                                      //clearing info
                tempstudent = new Student();
                ingrades.Clear();
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                Console.WriteLine(foo);
            }

        }
        public static void FilePrintOut()
        {
            /*allstudents.Sort(delegate (Student p1, Student p2)
            {
                int result = p1.getName().CompareTo(p2.getName());
                if (result == 0)
                    result = p1.getLastName().CompareTo(p2.getLastName());
                return result;
            });*/
            Console.WriteLine(String.Format("{0,-10} {1,-10} {2,15} {3,20:.##}", "Vardas", "Pavarde", "Galutinis(Vid.)/", "Galutinis(Med.)"));
            Console.WriteLine("-----------------------------------------------------------");
            for (int i = 0; i < allstudents.Count(); i++)
            {
                allstudents.ElementAt(i).PrintToConsoleStudentBoth();
            }
        }
        //
        public static void MENU()
        {

            string flag = " ";
            string caseSwitch = "";
            while (flag != "-e")
            {
                Console.WriteLine("1 - enter new students");
                Console.WriteLine("2 - get students from file");
                Console.WriteLine("3 - get student list with averages");
                Console.WriteLine("4 - get student list with mediana");
                Console.WriteLine("5 - Generate student file");
                Console.WriteLine("6 - Group students to file");
                Console.WriteLine("-e - exit");
                caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        Console.WriteLine("enter student count ");
                        int studentcount = Convert.ToInt32(Console.ReadLine());
                        EnterStudents(studentcount);
                        break;
                    case "2":
                        //
                        Console.WriteLine("Center file name (file must be on the desktop)");
                        string filepath = "C:\\Users\\User\\Desktop";
                        string filen = Console.ReadLine();
                        filepath = filepath + "\\" + filen + ".txt";
                        allstudents = HelpFunctions.Readfiledata(filepath);
                        //FilePrintOut();
                        break;
                    case "3":

                        if (HelpFunctions.StudentListCheck(allstudents) == false)
                        {
                            Console.WriteLine("List empty!");
                            break;
                        }
                        Console.WriteLine("Vardas     Pavardė        Galutinis(Vid.)");
                        Console.WriteLine("-----------------------------------------");
                        for (int i = 0; i < allstudents.Count(); i++)
                        {
                            try
                            {
                                allstudents.ElementAt(i).PrintToConsoleStudentAverage();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("There are no students!");
                                break;
                            }
                        }
                        break;
                    case "4":
                        Case4:
                        try
                        {
                            if (HelpFunctions.StudentListCheck(allstudents) == false)
                            {
                                break;
                            }
                            Console.WriteLine("Vardas     Pavardė        Galutinis(Med.)");
                            Console.WriteLine("-----------------------------------------");


                            for (int i = 0; i < allstudents.Count(); i++)
                            {
                                allstudents.ElementAt(i).PrintToConsoleStudentMediana();
                            }
                        }
                        catch (Exception ex)
                        {
                            //LogError(ex);
                            Console.WriteLine("There are no students!");
                        }
                        finally
                        {
                            //goto Case4;
                        }
                        break;

                    case "5":
                        Console.WriteLine("Set file directory ");
                        Console.WriteLine("Examples: ");
                        Console.WriteLine("Set file directory to Desktop: C:\\Users\\User\\Desktop\\ or -d");
                        Console.WriteLine("Set file directory to Documents: C:\\Users\\User\\Documents\\ or -doc");
                        string givenpath = Console.ReadLine();
                        if (givenpath == "-d")
                        { givenpath = "C:\\Users\\User\\Desktop\\"; }
                        if (givenpath == "-doc")
                        { givenpath = "C:\\Users\\User\\Documents\\"; }
                        Console.WriteLine("Give file a name: ");
                        string filename = Console.ReadLine();
                        givenpath += filename + ".txt";
                        Console.WriteLine("Give student count: ");
                        double studentscount = Convert.ToDouble(Console.ReadLine());
                        HelpFunctions.GenerateFile(givenpath, studentscount);
                        break;
                    case "6":
                        if (HelpFunctions.StudentListCheck(allstudents) == false)
                        {
                            Console.WriteLine("List empty!");
                            break;
                        }
                        HelpFunctions.StudentGrouping(allstudents);
                        Console.WriteLine("Students are grouped! ");
                        break;

                    case "-e":
                        flag = "-e";
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
