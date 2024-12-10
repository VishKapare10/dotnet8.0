// Extensions/IntExtensions.cs
using System;
using System.Text.RegularExpressions;
namespace ExtensionMethodDemo.Extensions
{
    public static class IntExtensions
    {
        // Extension method to check if an integer is even
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }


    public static class StringExtensions
    {
        // Extension method to check if the string is a valid email
        public static bool IsValidEmail(this string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
