using System.Numerics;

namespace CalculatorCLI;

public class MultiplyCommand : Command
{
    public override string Name => "mul";

    public override void ProcessArguments(string[] commandArgs)
    {
        if (commandArgs.Length == 0)
            return;
        var numbersToOperate = NumberType.All;
        if (commandArgs[0] == "even")
        {
            numbersToOperate = NumberType.Even;
            commandArgs = commandArgs.Skip(1).ToArray();
        }

        if (commandArgs[0] == "odd")
        {
            numbersToOperate = NumberType.Odd;
            commandArgs = commandArgs.Skip(1).ToArray();
        }

        if (commandArgs.Length == 0)
            return;

        if (commandArgs[0] == "-f" || commandArgs[^1] == "-f")
        {
            double product = 1;
            foreach (var arg in commandArgs.Where(arg => arg != "-f"))
            {
                var parsed = double.TryParse(arg, out var value);
                if (parsed)
                {
                    if (numbersToOperate == NumberType.All ||
                        numbersToOperate == NumberType.Odd && (value % 2 == 1 || value % 2 == -1) ||
                        numbersToOperate == NumberType.Even && value % 2 == 0)
                        product *= value;
                }
                else
                    Console.WriteLine($"Некорректное значение: {arg}");
            }

            Console.WriteLine(product);
        }
        else
        {
            BigInteger product = 1;
            foreach (var arg in commandArgs)
            {
                var parsed = BigInteger.TryParse(arg, out var value);
                if (parsed)
                {
                    if (numbersToOperate == NumberType.All ||
                        numbersToOperate == NumberType.Odd && (value % 2 == 1 || value % 2 == -1) ||
                        numbersToOperate == NumberType.Even && value % 2 == 0)
                        product *= value;
                }
                else
                    Console.WriteLine($"Некорректное значение: {arg}");
            }

            Console.WriteLine(product);
        }
    }
}