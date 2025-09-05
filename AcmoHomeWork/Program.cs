// See https://aka.ms/new-console-template for more information
using AcmoHomeWork;

Console.WriteLine("Hello, World!");

AdoDotNet service = new AdoDotNet();

Console.WriteLine("==Read==");
service.Read();

Console.WriteLine("==Create==");
service.Create();

Console.WriteLine("==Update==");
service.Update();

Console.WriteLine("==Delete==");
service.Delete();