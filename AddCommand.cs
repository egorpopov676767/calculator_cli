using System.Numerics;

namespace CalculatorCLI;

public class AddCommand:Command
{
    public override string Name => "add";
    public override string Description => "Суммирует числа";
    public readonly int ArgsCount = int.MaxValue;

    public override void ProcessArguments(string[] commandArgs)
    {
        if (commandArgs.Length == 0)
            return;
        if (commandArgs[0] == "-f" || commandArgs[^1] == "-f")
        {
            double sum = 0;
            foreach (var arg in commandArgs.Where(arg => arg != "-f"))
            {
                var parsed = double.TryParse(arg, out var value);
                if (parsed)
                    sum += value;
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
                    sum += value;
                else
                    Console.WriteLine($"Некорректное значение: {arg}");
            }
            Console.WriteLine(sum);
        }
    }
}