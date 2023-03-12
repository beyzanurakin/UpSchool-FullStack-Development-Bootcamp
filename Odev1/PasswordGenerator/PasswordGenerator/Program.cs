using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    class Program
    {
        private static bool upper, lower, number, special;
        private static int passwordLength;
        static void Main(string[] args)
        {
            Console.WriteLine(Messages.Questions.IncludeNumbers);
            number = PasswordGenerate.ReadInputs(Console.ReadLine());

            Console.WriteLine(Messages.Questions.IncludeLowercaseCharacters);
            lower = PasswordGenerate.ReadInputs(Console.ReadLine());

            Console.WriteLine(Messages.Questions.IncludeUppercaseCharacters);
            upper = PasswordGenerate.ReadInputs(Console.ReadLine());

            Console.WriteLine(Messages.Questions.IncludeSpecialCharacters);
            special = PasswordGenerate.ReadInputs(Console.ReadLine());

            Console.WriteLine(Messages.Questions.PasswordLength);
            passwordLength = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(PasswordGenerate.GeneratePassword(upper, lower, number, special, passwordLength));
            Console.ReadLine();
        }
    }
    public static class PasswordGenerate
    {
        private static string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string Lower = "abcdefghijklmnopqursuvwxyz";
        private static string Numbers = "123456789";
        private static string SpecialChars = @"!@£$%^&*()#€";

        public static string GeneratePassword(
            bool useUpper,
            bool useLower,
            bool useNumbers,
            bool useSpecial,
            int PasswordSize
            )
        {
            Random rand = new Random();
            string charSet = string.Empty;
            char[] password = new char[PasswordSize];

            if (useUpper) charSet += Upper;
            if (useLower) charSet += Upper.ToLower();
            if (useNumbers) charSet += Numbers;
            if (useSpecial) charSet += SpecialChars;

            for (int i =0; i< PasswordSize; i++)
            {
                password[i] = charSet[rand.Next(charSet.Length -1)];
            }
            return string.Join(null, password);
        }
        public static bool ReadInputs(string answer)
        {
            
            if (answer == "y" || answer == "Y")
            {
                
                return true;
            }
            else
            {
               
                return false;
            }
        }
    }
}
