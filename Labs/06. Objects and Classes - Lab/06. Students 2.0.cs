using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Students_2._0
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

                int count = 0;

                for (int i = 0; i < students.Count; i++)
                {
                    if(information[0] == students[i].firstName && information[1] == students[i].lastName)
                    {
                        students[i].age = int.Parse(information[2]);
                        students[i].homeTown = information[3];
                        count++;
                    }
                }

                if(count == 0)
                {
                    Student newOne = new Student(information[0], information[1], int.Parse(information[2]), information[3]);

                    students.Add(newOne);
                }              
            }
        }
    }

    class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string homeTown { get; set; }

        public Student(string fName, string lName, int inputAge, string town)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.age = inputAge;
            this.homeTown = town;
        }
    }
}
