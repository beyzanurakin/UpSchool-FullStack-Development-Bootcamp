using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Generator
    {
        private const string Uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Lowers = "abcdefghijklmnopqursuvwxyz";
        private const string Numbers = "123456789";
        private const string SpecialChars = @"!@£$%^&*()#€";
        private int _length = 0;
        private bool _isUserInputValid = true;

        private string _lastGeneratedPassword;
        private List<string> _generatedPasswords;

        private readonly Random _random;
        private readonly StringBuilder _passwordBuilder;
        private readonly StringBuilder _charSetBuilder;

        public bool IncludeNumbers { get; set; }
        public bool IncludeLowercaseCharacters { get; set; }
        public bool IncludeUppercaseCharacters { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
        
        public Generator() 
        {
            _random = new Random();
            _passwordBuilder = new StringBuilder();
            _charSetBuilder = new StringBuilder();
            _lastGeneratedPassword = String.Empty;
            _generatedPasswords = new List<string>();
        }
        public void Greetings()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("Welcome to the Random Password Generator!");
            Console.WriteLine("*****************************************");
        }
        public void ReadInputs()
        {
            Console.WriteLine(Messages.Questions.IncludeNumbers);
            IncludeNumbers = Console.ReadLine()?.ToLower() == "y";

            Console.WriteLine(Messages.Questions.IncludeLowercaseCharacters);
            IncludeLowercaseCharacters = Console.ReadLine()?.ToLower() == "y";

            Console.WriteLine(Messages.Questions.IncludeUppercaseCharacters);
            IncludeUppercaseCharacters = Console.ReadLine()?.ToLower() == "y";

            Console.WriteLine(Messages.Questions.IncludeSpecialCharacters);
            IncludeSpecialCharacters = Console.ReadLine()?.ToLower() == "y";

            Console.WriteLine(Messages.Questions.PasswordLength);
            var passwordLength = Console.ReadLine();

            if(!int.TryParse(passwordLength, out _length) || 
                !IncludeNumbers && 
                !IncludeLowercaseCharacters && 
                !IncludeUppercaseCharacters &&
                !IncludeSpecialCharacters
                )
            {
                _isUserInputValid = false;
                return;
            }
            _isUserInputValid = true;

        }



        private void ShowErrorMessage(string? message = null)
        {
            if(string.IsNullOrEmpty(message))
            {
                Console.WriteLine("password can not be created");
                return;

            }
            Console.WriteLine(message);
        }
       
        public void Generate()
        {
            Console.WriteLine( "Generate");
            if (!_isUserInputValid)
            {
                ShowErrorMessage();
                return;
            }
            if (IncludeNumbers) _charSetBuilder.Append(Numbers);
            if (IncludeLowercaseCharacters) _charSetBuilder.Append(Lowers);
            if (IncludeUppercaseCharacters) _charSetBuilder.Append(Uppers);
            if (IncludeSpecialCharacters) _charSetBuilder.Append(SpecialChars);

            var charSet = _charSetBuilder.ToString();

            for (int i = 0; i < _length; i++)
            {
                var randomIndex = _random.Next(charSet.Length);
                _passwordBuilder.Append(charSet[randomIndex]);
            }

            _lastGeneratedPassword = _passwordBuilder.ToString();
            _generatedPasswords.Add(_lastGeneratedPassword);
            _charSetBuilder.Clear();
            _passwordBuilder.Clear();
        }

        //public string GetLatestGeneratedPassword() => _lastGeneratedPassword;
        //public List<string> GetGeneratedPasswords() => _generatedPasswords;
        public void WriteLatestGeneratedPassword() => WriteFormattedPassword(_lastGeneratedPassword);
        //public void WriteGeneratedPasswords() => _generatedPasswords.ForEach(WriteFormattedPassword);
        public void WriteFormattedPassword(string? password)
        {
            
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(password);
            
            Console.WriteLine("------------------------------------------------");
        }
       
       

    }
}
