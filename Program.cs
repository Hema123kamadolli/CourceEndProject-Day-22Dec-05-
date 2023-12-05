using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


using System.Text;
using System.Threading.Tasks;

namespace CourceEndProject_2
{
    internal class Program
    {
        //File path where teacher information is stored
        static string filePath = "C:\\mphasis-B2\\Day-22\\CourceEndProject-2\\CourceEndProject-2\\RainboSchool.txt";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Teacher\n2. Update Teacher\n3. Exit");
                //Read the input from user
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();//Call the method to add teacher
                        break;
                    case 2:
                        UpdateTeacher();//Call the method to update a teacher
                        break;
                    case 3:
                        Environment.Exit(0);//Exist the program
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again. ");
                        break;
                }
            }
        }
        //Method to add a new Teacher
        static void AddTeacher()
        {
            Console.WriteLine("Enter Teacher ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Teacher Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Class and Section:");
            string classSection = Console.ReadLine();
            
            //Creating Teacher object with user input
            Teacher teacher = new Teacher { ID = id, Name = name, ClassSection = classSection };

            //Read existing lines from the File
            List<string> lines = File.ReadAllLines(filePath).ToList();

            //Adding new teacher information to the list
            lines.Add($"{teacher.ID}\t\t{teacher.Name}\t\t{teacher.ClassSection}");

            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Teacher added Successfuly!!");
        }
        // Method to update an existing teacher's information
        static void UpdateTeacher()
        {
            Console.WriteLine("Enter Teacher ID to update:");
            int idToUpdate = int.Parse(Console.ReadLine());

            // Read existing lines from the file
            List<string> lines = File.ReadAllLines(filePath).ToList();
            bool found = false;

            // Iterate through each line to find and update the specified teacher
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split('\t');
                if (int.TryParse(parts[0], out int id))
                {

                    if (id == idToUpdate)
                    {
                        Console.WriteLine("Enter New Name:");
                        string newName = Console.ReadLine();

                        Console.WriteLine("Enter New Class and Section:");
                        string newClassSection = Console.ReadLine();

                        // Update the line with the new teacher information
                        lines[i] = $"{idToUpdate}\t\t{newName}\t\t{newClassSection}";
                        found = true;
                    }
                }
            }
                File.WriteAllLines(filePath, lines);
            // Display a message if the specified teacher is not found
            if (!found)
                {
                    Console.WriteLine("Teacher not found!");
                }
                else
                {
                    Console.WriteLine("TeacherUpdated SuccessFuly!!");
                }
            
            Console.ReadKey();
        }
    }
}
