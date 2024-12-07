namespace CalculatorCLI;

public abstract class Command
{
    public abstract string Name { get; }
    
    public abstract void ProcessArguments(string[] commandArgs);
}