using System;

namespace _01._Bonus_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());

            int countLectures = int.Parse(Console.ReadLine());

            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonusPoints = 0;
            double maxAttendances = 0;

            for (int i = 0; i < countStudents; i++)
            {
                double countAttendances = int.Parse(Console.ReadLine());

                double currentBonus = (countAttendances / countLectures * (5 + additionalBonus));

                if (currentBonus > maxBonusPoints)
                {
                    maxBonusPoints = currentBonus;
                    maxAttendances = countAttendances;
                }
            }

            Console.WriteLine($"The maximum bonus score for this course is {Math.Ceiling(maxBonusPoints)}.The student has attended {maxAttendances} lectures.");
        }
    }
}
