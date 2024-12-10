// Program.cs
using System;
using ExtensionMethodDemo.Extensions;  // Import the namespace for extensions

namespace ExtensionMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test the IntExtensions
            int number = 10;
            bool isEven = number.IsEven();  // Using the extension method
            Console.WriteLine($"{number} is even: {isEven}");

            // Test the StringExtensions
            string email = "example@domain.com";
            bool isValidEmail = email.IsValidEmail();  // Using the extension method
            Console.WriteLine($"Is '{email}' a valid email? {isValidEmail}");

            // Another example with a different email
            string invalidEmail = "invalid-email";
            bool isValidInvalidEmail = invalidEmail.IsValidEmail();  // Using the extension method
            Console.WriteLine($"Is '{invalidEmail}' a valid email? {isValidInvalidEmail}");
        }
    }
}
