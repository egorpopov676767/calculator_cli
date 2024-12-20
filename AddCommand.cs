using System.Numerics;

namespace CalculatorCLI;

public class AddCommand : Command
{
    public override string Name => "add";

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

        if (commandArgs[0] == "-f" || commandArgs[^1] == "-f")
        {
            double sum = 0;
            foreach (var arg in commandArgs.Where(arg => arg != "-f"))
            {
                var parsed = double.TryParse(arg, out var value);
                if (parsed)
                {
                    if (ns == NumberType.All ||
                        ns == NumberType.Odd && (value % 2 == 1 || value % 2 == -1) ||
                        ns == NumberType.Even && value % 2 == 0)
                        sum += value;
                }
                else
                    Console.WriteLine($"Некорректное значение: {arg}");
            }

            Console.WriteLine(sum);
        }
        else
        {
            BigInteger sum = 0;
            foreach (var arg in commandArgs)
            {
                var parsed = BigInteger.TryParse(arg, out var value);
                if (parsed)
                {
                    if (ns == NumberType.All ||
                        ns == NumberType.Odd && (value % 2 == 1 || value % 2 == -1) ||
                        ns == NumberType.Even && value % 2 == 0)
                        sum += value;
                }
                else
                    Console.WriteLine($"Некорректное значение: {arg}");
            }

            Console.WriteLine(sum);
        }
    }
}