namespace CalculatorCLI;

public class HelpCommand : Command
{
    public override string Name => "";

    public override void ProcessArguments(string[] commandArgs)
    {
        Console.WriteLine("help: выводит подробную информацию о командах");
        Console.WriteLine("add: суммирует числа");
        Console.WriteLine("mul: перемножает числа");
        Console.WriteLine("sub: вычитает из первого числа все последующие");
        Console.WriteLine("div: делит на первое число все последующие");
        Console.WriteLine("op even: выполнить операцию только для чётных чисел");
        Console.WriteLine("op odd: выполнить операцию только для нечётных чисел");
        Console.WriteLine("-f: принимать числа типа float (перед аргументами или после)");
    }
}