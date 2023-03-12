using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Generator
    {
        private static string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string Lower = "abcdefghijklmnopqursuvwxyz";
        private static string Numbers = "123456789";
        private static string SpecialChars = @"!@£$%^&*()#€";
        private static string GeneratedPassword;
        public Generator() 
        {
         
        }
        public void Greetings()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("Welcome to the Random Password Generator!");
            Console.WriteLine("*****************************************");
        }
        public void GenerateLastPassword()
        {
            bool upper, lower, number, special;
            int passwordLength;

            Console.WriteLine(Messages.Questions.IncludeNumbers);
            number = ReadInputs(Console.ReadLine());

            Console.WriteLine(Messages.Questions.IncludeLowercaseCharacters);
            lower = ReadInputs(Console.ReadLine());

            Console.WriteLine(Messages.Questions.IncludeUppercaseCharacters);
            upper = ReadInputs(Console.ReadLine());

            Console.WriteLine(Messages.Questions.IncludeSpecialCharacters);
            special = ReadInputs(Console.ReadLine());

            Console.WriteLine(Messages.Questions.PasswordLength);
            passwordLength = Convert.ToInt32(Console.ReadLine());


            GeneratedPassword = GeneratePassword(upper, lower, number, special, passwordLength);
          
        }
        public bool ReadInputs(string answer)
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
        public void WriteGeneratedPassword()
        {
            
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(GeneratedPassword);
            Console.WriteLine("------------------------------------------------");
        }
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

            for (int i = 0; i < PasswordSize; i++)
            {
                password[i] = charSet[rand.Next(charSet.Length - 1)];
            }
            return string.Join(null, password);
        }

    }
}
