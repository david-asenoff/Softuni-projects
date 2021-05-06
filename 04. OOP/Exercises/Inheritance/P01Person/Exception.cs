using System;
using System.Collections.Generic;
using System.Text;

namespace P01Person
{
    public static class Exception
    {
        public static string AgeCannotBeNegativeException()
        {
            return "Age can not be negative!";
        }

        public static string ChildCannotBeAboveFifteen()
        {
            return "A child age cannot be above 15";
        }
    }
}