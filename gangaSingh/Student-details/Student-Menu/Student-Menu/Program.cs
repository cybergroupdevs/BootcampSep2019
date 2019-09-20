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

                        StreamReader sr = new StreamReader("E:/Student-details/Student-Menu/Text-file.txt");

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

                    string path = @"E:/Student-details/Student-Menu/Text-file.txt";

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

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        Console.WriteLine("Enter Student Details below : ");
                        inputLine = Console.ReadLine();
                        sw.WriteLine(inputLine);
                        sw.Close();
                    }
                    break;

                case 3:
                    String OldText,
                    NewInput;
                    string text = File.ReadAllText("E:/Student-details/Student-Menu/Text-file.txt");
                    Console.WriteLine("Enter the Student name to update : ");
                    OldText = Console.ReadLine();
                    Console.WriteLine("Enter the new detail of the Student : ");
                    NewInput = Console.ReadLine();
                    text = text.Replace(OldText, NewInput);
                    File.WriteAllText("E:/Student-details/Student-Menu/Text-file.txt", text);
                    break;

                case 4:
                    string tempFile = Path.GetTempFileName();
                    Console.Write("Input your text you want to delete: ");
                    var textTodelete = Console.ReadLine();
                    using (var sr = new StreamReader("E:/Student-details/Student-Menu/Text-file.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string lineByLine;

                        while ((lineByLine = sr.ReadLine()) != null)
                        {
                            if (lineByLine != textTodelete) sw.WriteLine(lineByLine);
                        }
                    }

                    File.Delete("E:/Student-details/Student-Menu/Text-file.txt");
                    File.Move(tempFile, "E:/Student-details/Student-Menu/Text-file.txt");
                    break;
                case 5:
                    Console.Write("Input your search text: ");
                    var textToSearch = Console.ReadLine();
                    List<List<string>> groups = new List<List<string>>();
                    List<string> current = null;
                    foreach (var lineInLoop in File.ReadAllLines("E:/Student-details/Student-Menu/Text-file.txt"))
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