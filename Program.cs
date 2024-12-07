using System;
using System.Numerics;
using CalculatorCLI;

public static class Program
{
    public static Command[] commands =
    {
        new AddCommand(), new MultiplyCommand(),
        new SubtractCommand(), new DivideCommand(), new HelpCommand()
    };

    static void Main1(string[] args)
    {
        var sw = new StringWriter();
        var consoleOut = Console.Out;
        Console.SetOut(sw);
        ProcessCommand(args);
        Console.SetOut(consoleOut);
        Console.WriteLine(sw.ToString());
    }

    public static void ProcessCommand(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Введите команду в поле аргументов");
            return;
        }

        foreach (var command in commands)
        {
            if (args[0] == command.Name)
            {
                command.ProcessArguments(args.Skip(1).ToArray());
                break;
            }
        }
    }
}