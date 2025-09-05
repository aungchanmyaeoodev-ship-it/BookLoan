// See https://aka.ms/new-console-template for more information
using EFCore.ConsoleApp;
Console.WriteLine("Hello, World!");

EFCoreService ef = new EFCoreService();

Console.WriteLine("===Read===");
ef.Read();

Console.WriteLine("===Create===");
ef.Create();

Console.WriteLine("===Update===");
ef.Update();

Console.WriteLine("===Delete===");
ef.Delete();