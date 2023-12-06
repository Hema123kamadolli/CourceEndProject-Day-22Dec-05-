using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CourceEndProject_2
{
    internal class Program
    {
        // File path to store teacher data
        static string filePath = "C:\\mphasis-B2\\Day-22\\CourceEndProject-2\\CourceEndProject-2\\TeachersData.txt";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("****Store and Update of Teachers Data****");
                Console.WriteLine("1. Add Teacher.");
                Console.WriteLine("2. Update Teacher.");
                Console.WriteLine("3. Display Teachers.");
                Console.WriteLine("4. Exit.");

                // User choice for the options
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;
                    case 2:
                        UpdateTeacher();
                        break;
                    case 3:
                        DisplayTeachers();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Method to add a new teacher
        static void AddTeacher()
        {
            Console.WriteLine("Enter Teacher ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Teacher Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter ClassAndSection:");
            string classSection = Console.ReadLine();

            // Create a Teacher object with the provided information
            Teacher teacher = new Teacher { ID = id, Name = name, ClassSection = classSection };

            // Read existing lines from the file
            List<string> lines = File.ReadAllLines(filePath).ToList();

            // Add new teacher information to the list of lines
            lines.Add($"{teacher.ID}\t\t{teacher.Name}\t\t{teacher.ClassSection}");

            // Write the updated lines back to the file
            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Teacher added successfully!!");
        }

        // Method to update an existing teacher
        static void UpdateTeacher()
        {
            Console.WriteLine("Enter Teacher ID to update:");
            int idToUpdate = int.Parse(Console.ReadLine());

            // Read existing lines from the file
            List<string> lines = File.ReadAllLines(filePath).ToList();
            bool found = false;

            // Iterate through each line to find the teacher to update
            for (int i = 0; i < lines.Count; i++)
            {
                // Split the line into parts using tab ('\t')
                string[] parts = lines[i].Split('\t');

                // Try to parse the first part as an integer (teacher ID)
                if (int.TryParse(parts[0], out int id))
                {
                    if (id == idToUpdate)
                    {
                        Console.WriteLine("Enter New Name:");
                        string newName = Console.ReadLine();

                        Console.WriteLine("Enter New ClassAndSection:");
                        string newClassSection = Console.ReadLine();

                        // Update the line with the new information
                        lines[i] = $"{idToUpdate}\t\t{newName}\t\t{newClassSection}";
                        found = true;
                    }
                }
            }

            // Write the updated lines back to the file
            File.WriteAllLines(filePath, lines);

            if (!found)
            {
                Console.WriteLine("Teacher not found!");
            }
            else
            {
                Console.WriteLine("Teacher updated successfully!!");
            }
        }
        //Method to Diplay Record of Teachers
        static void DisplayTeachers()
        {
            Console.WriteLine("Teachers Records:");
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();

            
        }
       
    }
}

    
