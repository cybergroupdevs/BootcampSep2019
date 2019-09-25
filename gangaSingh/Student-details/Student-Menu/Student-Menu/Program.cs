using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Student_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            Console.WriteLine("Options");
            Console.WriteLine("1. View all students");

            Console.WriteLine("2. Add new Student");

            Console.WriteLine("3. Update new student");

            Console.WriteLine("4. Delete Student Details");

            Console.WriteLine("5. Search student name");

            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    String line;
                    try
                    {

                        StreamReader sr = new StreamReader("E:/BootcampSep2019-master/BootcampSep2019/gangaSingh/Student-details/Student-Menu/Text-file.txt");


                        line = sr.ReadLine();

                        while (line != null)
                        {

                            Console.WriteLine(line);

                            line = sr.ReadLine();
                        }

                        sr.Close();
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }
                    break;

                case 2:
                    String inputLine;

                    string path = @"E:/BootcampSep2019-master/BootcampSep2019/gangaSingh/Student-details/Student-Menu/Text-file.txt";

                    if (!File.Exists(path))
                    {

                        using (StreamWriter sw = File.CreateText(path))
                        {
               
                            Console.WriteLine("Enter Student Details below : ");
                            inputLine = Console.ReadLine();
                            sw.WriteLine(inputLine);
                            sw.Close();
                        }
                    }
                    String inputId, FirstName, LastName, City, State;
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        Console.WriteLine("Enter Student id : ");
                        inputId = Console.ReadLine();
                        //sw.WriteLine(inputId);
                        Console.WriteLine("Enter Student Fisrt Name : ");
                        FirstName = Console.ReadLine();
                       // sw.WriteLine(FirstName);
                        Console.WriteLine("Enter Student Last Name : ");
                        LastName = Console.ReadLine();
                       // sw.WriteLine(LastName,FirstName);
                        Console.WriteLine("Enter Student City : ");
                        City = Console.ReadLine();
                        //sw.WriteLine(City);
                        Console.WriteLine("Enter Student State : ");
                        State = Console.ReadLine();
                        
                       
                        String DummyLine = inputId+ " " + FirstName + " " + LastName + " " + City + " " + State;
                        sw.WriteLine(DummyLine);
                        sw.Close();
                    }
                    break;

                case 3:
                    String OldText,IDstudent,NewInput;
                    string text = File.ReadAllText("E:/BootcampSep2019-master/BootcampSep2019/gangaSingh/Student-details/Student-Menu/Text-file.txt");
                    Console.WriteLine("Enter the Student Id to update : ");
                    IDstudent = Console.ReadLine();
                    string[] lines = File.ReadAllLines(text);
                    string[] words;

                    foreach (string lineInFile in lines)
                    {
                        words = lineInFile.Split(' ');
                    }
                    // Console.WriteLine(lineInFile);
                    Console.WriteLine("Enter the detail you want to update: 1 firstName 2 LastName 3 State 4 City ");
                    int casesInput;
                    casesInput = Convert.ToInt32(Console.ReadLine());
                    switch (casesInput)
                    {
                        case 1:
                            Console.WriteLine("Enter the new detail of the Student : ");
                            NewInput = Console.ReadLine();
                            // String lineTOChange = Array.Find(words, "1");
                            // = NewInput;
                           // string[] words1 = words;
                            foreach (var word in words)
                            {
                                System.Console.WriteLine($"<{word}>");
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }




                    Console.WriteLine("Enter the Student Name to update : ");
                    OldText = Console.ReadLine();
                    
                    text = text.Replace(OldText, NewInput);
                    File.WriteAllText("E:/BootcampSep2019-master/BootcampSep2019/gangaSingh/Student-details/Student-Menu/Text-file.txt", text);
                    break;

                case 4:
                    string tempFile = Path.GetTempFileName();
                    Console.Write("Input your text you want to delete: ");
                    var textTodelete = Console.ReadLine();
                    using (var sr = new StreamReader("E:/BootcampSep2019-master/BootcampSep2019/gangaSingh/Student-details/Student-Menu/Text-file.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string lineByLine;

                        while ((lineByLine = sr.ReadLine()) != null)
                        {
                            if (lineByLine != textTodelete) sw.WriteLine(lineByLine);
                        }
                    }

                    File.Delete("E:/BootcampSep2019-master/BootcampSep2019/gangaSingh/Student-details/Student-Menu/Text-file.txt");
                    File.Move(tempFile, "E:/BootcampSep2019-master/BootcampSep2019/gangaSingh/Student-details/Student-Menu/Text-file.txt");
                    break;
                case 5:
                    Console.Write("Input your search text: ");
                    var textToSearch = Console.ReadLine();
                    List<List<string>> groups = new List<List<string>>();
                    List<string> current = null;
                    foreach (var lineInLoop in File.ReadAllLines("E:/BootcampSep2019-master/BootcampSep2019/gangaSingh/Student-details/Student-Menu/Text-file.txt"))
                    {
                        if (lineInLoop.Contains(textToSearch) && current == null) current = new List<string>();
                        else if (lineInLoop.Contains(textToSearch) && current != null)
                        {
                            groups.Add(current);
                            current = null;
                        }
                        if (current != null)
                        {
                            current.Add(lineInLoop);
                            Console.WriteLine(lineInLoop);
                            Console.ReadLine();
                        }

                    }
                    break;
            }

        }
    }
}