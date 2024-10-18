using System;
using System.Numerics;
using CalculatorCLI;

public static class Program
{
    public static Command[] commands = { new AddCommand(), new HelpCommand() };
    
    static void Main(string[] args)
    {
        ProcessCommand(args);
    }

    static void ProcessCommand(string[] args)
    {
        if(args.Length==0)
        {
            Console.WriteLine("Введите команду в поле аргументов");
            return;
        }
        
        foreach (var command in commands)
        {
            if(args[0] == command.Name) command.ProcessArguments(args.Skip(1).ToArray());
        }
    }
}