using System.Numerics;

namespace CalculatorCLI;

public class DivideCommand : Command
{
    public override string Name => "div";

    public override void ProcessArguments(string[] commandArgs)
    {
        if (commandArgs.Length == 0)
            return;
        var ns = NumberType.All;
        if (commandArgs[0] == "even")
        {
            ns = NumberType.Even;
            commandArgs = commandArgs.Skip(1).ToArray();
        }

        if (commandArgs[0] == "odd")
        {
            ns = NumberType.Odd;
            commandArgs = commandArgs.Skip(1).ToArray();
        }

        if (commandArgs.Length == 0)
            return;

        var isFirstValue = true;
        if (commandArgs[0] == "-f" || commandArgs[^1] == "-f")
        {
            double res = 1;
            foreach (var arg in commandArgs.Where(arg => arg != "-f"))
            {
                var parsed = double.TryParse(arg, out var value);
                if (parsed)
                {
                    if (ns == NumberType.All ||
                        ns == NumberType.Odd && (value % 2 == 1 || value % 2 == -1) ||
                        ns == NumberType.Even && value % 2 == 0)
                    {
                        if (isFirstValue)
                        {
                            res = value;
                            isFirstValue = false;
                        }
                        else
                        {
                            if (value == 0)
                                Console.WriteLine("Деление на ноль запрещено");
                            else
                                res /= value;
                        }
                    }
                }
                else
                    Console.WriteLine($"Некорректное значение: {arg}");
            }

            Console.WriteLine(res);
        }
        else
        {
            BigInteger res = 1;
            foreach (var arg in commandArgs)
            {
                var parsed = BigInteger.TryParse(arg, out var value);
                if (parsed)
                {
                    if (ns == NumberType.All ||
                        ns == NumberType.Odd && (value % 2 == 1 || value % 2 == -1) ||
                        ns == NumberType.Even && value % 2 == 0)
                    {
                        if (isFirstValue)
                        {
                            res = value;
                            isFirstValue = false;
                        }
                        else
                        {
                            if (value == 0)
                                Console.WriteLine("Деление на ноль запрещено");
                            else
                                res /= value;
                        }
                    }
                }
                else
                    Console.WriteLine($"Некорректное значение: {arg}");
            }

            Console.WriteLine(res);
        }
    }
}