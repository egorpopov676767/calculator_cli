namespace CalculatorCLI;

public abstract class Command
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public readonly int ArgsCount = 0;
    
    public abstract void ProcessArguments(string[] commandArgs);
}