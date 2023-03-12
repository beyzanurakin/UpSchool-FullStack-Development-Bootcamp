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
        
        static void Main(string[] args)
        {
            var generator = new Generator();
            generator.Greetings();
       
            generator.GenerateLastPassword();
            generator.WriteGeneratedPassword();
            Console.ReadLine();
            
        }
    }
}
