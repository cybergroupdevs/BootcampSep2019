using System;
using System.IO;
namespace Task
{
    
    class Program
    {
        private static string path1;
        private static object xx;
        
        static void Main(string[] args)
        {
            
            string path1 = @"C:\Users\chandan\Desktop\Task\File.txt";
            Boolean a = true;
            while (a)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1. View all students");
                Console.WriteLine("2. Add new student");
                Console.WriteLine("3. Update student details");
                Console.WriteLine("4. Delete student details");
                Console.WriteLine("5. Search student by name");
                Console.WriteLine("Select option:");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        viewallstudents(path1);
                        break;
                    case 2:
                        FileStream x = new FileStream(path1, FileMode.Append, FileAccess.Write);
                        StreamWriter xx = new StreamWriter(x);
                        String add = addnewstudent();
                        xx.WriteLine(add);
                        xx.Close();
                        x.Close();
                        break;
                    case 3:
                        updatestudentdetails(path1);
                        break;
                    case 4:
                        deletestudentdetails(path1);
                        break;
                    case 5:
                        searchstudentbyname(path1);
                        break;
                    default:
                        Console.WriteLine("User input is invalid");
                        Console.Clear();
                        break;
                }
                Console.ReadKey();
                Console.WriteLine("plz enter 1 to see menu or 0 to exit");
                int run = Convert.ToInt32(Console.ReadLine());
                if(run==1)
                {
                    a = true;
                }
                else
                {
                    a = false;
                }

            }
        }

        private static void deletestudentdetails(string path1)
        {
            string[] del = File.ReadAllLines(path1);
            string str= "";
            Console.WriteLine("Enter id of student you want to delete");
            String x = Console.ReadLine();
            for(int i=0;i<del.Length;i++)
            {
                if(!del[i].Contains(x))
                {
                    str = str + del[i] + Environment.NewLine;
                }
            }
            File.WriteAllText(path1,str);
            Console.WriteLine("ID you enter is deleted");
            Console.WriteLine("plz  click enter to continue");
            Console.WriteLine();
        }

        private static void searchstudentbyname(string path1)
        {
            string[] search = File.ReadAllLines(path1);
            Console.WriteLine("Plz enter the name of student");
            String find = Console.ReadLine();
            Boolean flag = false;
            for(int i=0;i<search.Length;i++)
            {
                if(search[i].Contains(find)==true)
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if(flag==true)
            {
                Console.WriteLine("Record Found");
                Console.WriteLine("plz click enter to continue");
            }
            else
            {
                Console.WriteLine(" No Record Found");
                Console.WriteLine("plz  click enter to continue");
               
            }

        }

        private static void updatestudentdetails(string path1)
        {
            string[] search = File.ReadAllLines(path1);
            string str = "";
            Console.WriteLine("Enter the id of the student");
            string find = Console.ReadLine();
            for(int i=0;i<search.Length;i++)
            {
                if(search[i].Contains(find))
                {
                    Console.WriteLine("Enter old string");
                    string old = Console.ReadLine();
                    Console.WriteLine("Enter new string");
                    string new1 = Console.ReadLine();
                    str=str+search[i].Replace(old, new1)+Environment.NewLine;
                    Console.WriteLine("Your data is updated now");
                    Console.WriteLine("plz  click enter to continue");
                    Console.WriteLine();
                }
                else
                {
                    str = str + search[i]+Environment.NewLine;
                }
            }
            File.WriteAllText(path1, str);
        }

        private static string addnewstudent()
        {
            string str = "";
            Console.WriteLine("StudentId");
            String id = Console.ReadLine();
            str = str + id+",";
            Console.WriteLine("FirstName");
            String fname = Console.ReadLine();
            str = str + fname + ",";
            Console.WriteLine("LastName");
            String lname = Console.ReadLine();
            str = str + lname + ",";
            Console.WriteLine("City");
            String city = Console.ReadLine();
            str = str + city + ",";
            Console.WriteLine("State");
            String state = Console.ReadLine();
            str = str + state + "\n";
            Console.WriteLine("Your record is added");
            Console.WriteLine();
            Console.WriteLine("plz click enter to continue");
            return str;

        }

        private static void viewallstudents(string path1)
        {
            string[] len = File.ReadAllLines(path1);
            for (int i=0;i<len.Length;i++)
            {
               Console.WriteLine(len[i]);
            }
            Console.WriteLine("plz click enter to continue");
            Console.WriteLine();
        }
    }
}
