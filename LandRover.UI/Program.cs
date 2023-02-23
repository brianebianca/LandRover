//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using LandRover.Core.Utils;

Console.WriteLine($"Hi");
//string name = Environment.GetCommandLineArgs()[0];
string file = Console.ReadLine();
Console.WriteLine($"Reading file {file}!");

var commands = FileReader.ReadFile( file );
foreach (string line in commands)
    Console.WriteLine(line);
