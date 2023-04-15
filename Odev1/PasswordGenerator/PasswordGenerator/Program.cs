using PasswordGenerator;
using System;

var generator = new Generator();

generator.Greetings();

generator.ReadInputs();

generator.Generate();

generator.WriteLatestGeneratedPassword();

Console.ReadLine();
return 0;
