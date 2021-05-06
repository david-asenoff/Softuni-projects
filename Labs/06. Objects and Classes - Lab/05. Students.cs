using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    string city = Console.ReadLine();

                    List<Student> selectedStudents = students.Where(s => s.homeTown == city).ToList();

                    foreach (Student st in selectedStudents)
                    {
                        Console.WriteLine($"{st.firstName} {st.lastName} is {st.age} years old.");
                    }

                    break;
                }

                List<string> information = input.Split(' ').ToList();

                Student newOne = new Student(information[0], information[1], int.Parse(information[2]), information[3]);

                students.Add(newOne);
            }
        }
    }

    class Student
    {
        public string firstName;
        public string lastName;
        public int age;
        public string homeTown;

        public Student(string fName, string lName, int inputAge, string town)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.age = inputAge;
            this.homeTown = town;
        }
    }
}
