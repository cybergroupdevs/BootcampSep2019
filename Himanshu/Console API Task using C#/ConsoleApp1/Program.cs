using System;
using System.Collections.Generic;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {
        Dictionary<string, int> dict;
        static string path = "E:\\Sample.txt";

        Program()
        {
            dict = new Dictionary<string,int>();
            dict.Add("id",0);
            dict.Add("firstname",1);
            dict.Add("lastname",2);
            dict.Add("city",3);
            dict.Add("state",4);
        }
        
        void getMenu()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. View all students");
            Console.WriteLine("2. Add new student");
            Console.WriteLine("3. Update student details");
            Console.WriteLine("4. Delete student details");
            Console.WriteLine("5. Search student by name");
            Console.WriteLine("6. Exit");
        }

        void SearchStudentByName()
        {
            String name, line;
            Console.Write("Enter student name to search : ");
            name = Console.ReadLine();
            char[] sep = { ' ' };
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            while (line != null)
            {
                string[] strlist = line.Split(sep, 6, StringSplitOptions.RemoveEmptyEntries);
                if(name == strlist[1] || name == strlist[2])
                {
                    Console.WriteLine(line);
                    break;
                }
                line = sr.ReadLine();
            }
            sr.Close();
        }

        void ViewStudentsRecord()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        void AddNewStudent()
        {
            string first_name, last_name, city, state, student_id;
            Console.Write("Enter Student ID : ");
            student_id = Console.ReadLine();
            Console.Write("Enter First Name : ");
            first_name = Console.ReadLine();
            Console.Write("Enter Last Name : ");
            last_name = Console.ReadLine();
            Console.Write("Enter City : ");
            city = Console.ReadLine();
            Console.Write("Enter State : ");
            state = Console.ReadLine();

            StreamReader sr = new StreamReader(path);
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    String output = student_id + " " + first_name + " " + last_name + " " + city + " " + state;
                    sw.WriteLine(output);
                }
            }
            sr.Close();
            using (StreamWriter sw = File.AppendText(path))
            {
                String output = student_id + " " + first_name + " " + last_name + " " + city + " " + state;
                sw.WriteLine(output);
            }
            sr.Close();

        }

        void UpdateExistingStudent()
        {
            String type,line,id,stringLine,newLine;
            
            int i = 0;
            List<String> finalLine = new List<string>();
            char[] sep = { ' ' };
            Console.Write("Enter type of detail you want to update (id,firstname,lastname,city,state) : ");
            type = Console.ReadLine();
            Console.Write("Enter ID : ");
            id = Console.ReadLine();
            Console.Write("Enter new value : ");
            newLine = Console.ReadLine();
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            while (line != null)
            {
                bool status = false;
                stringLine = Char.ToString(line[0]);
                if(id == stringLine)
                {
                    string[] strlist = line.Split(sep,6,StringSplitOptions.RemoveEmptyEntries);
                    status = true;
                    strlist[dict[type]] = newLine;
                    String result = string.Join(" ", strlist);
                    finalLine.Add(result);
                }
                if(status == false)
                {
                    finalLine.Add(line);
                }
                i++;
                line = sr.ReadLine();
            }
            sr.Close();
            File.Delete(path);
            foreach (string s in finalLine)
            {
                using (StreamWriter sd = File.AppendText(path))
                {
                    sd.WriteLine(s);
                }
            }
        }

        void DeleteStudentDetails()
        {
            string id, line, stringLine;
            List<String> finalLine = new List<string>();
            Console.Write("Enter Student ID : ");
            id = Console.ReadLine();
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            while(line != null)
            {
                stringLine = Char.ToString(line[0]);
                if(id != stringLine)
                {
                    finalLine.Add(line);
                }
                line = sr.ReadLine();
            }
            sr.Close();
            File.Delete(path);
            foreach (string s in finalLine)
            {
                using (StreamWriter sd = File.AppendText(path))
                {
                    sd.WriteLine(s);
                }
            }

        }

        
        static void Main(string[] args)
        {
            int choice;
            Program obj = new Program();
            obj.getMenu();
            bool status = true;
            
            while (status)
            {
                Console.Write("Enter Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        obj.ViewStudentsRecord();
                        break;
                    case 2:
                        obj.AddNewStudent();
                        break;
                    case 3:
                        obj.UpdateExistingStudent();
                        break;
                    case 4:
                        obj.DeleteStudentDetails();
                        break;
                    case 5:
                        obj.SearchStudentByName();
                        break;
                    case 6:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }
}
