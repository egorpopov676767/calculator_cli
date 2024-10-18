namespace CalculatorCLI;

public class HelpCommand:Command
{
    public override string Name => "help";
    public override string Description => "Выводит подробную информацию о командах";
    public override void ProcessArguments(string[] commandArgs)
    {
        foreach (var command in Program.commands)
        {
            Console.WriteLine($"{command.Name}: {command.Description}");
        }

        ;
    }

    public readonly int ArgsCount = 0;
}