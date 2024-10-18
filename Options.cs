using CommandLine;

public class Options
{
    [Option("add", Separator = ' ', HelpText = "Числа, которые будут добавлены.")]
    public IEnumerable<string> NumberStrings { get; set; }

    [Option('f', "float", Required = false, HelpText = "Принять числа типа float64.")]
    public bool AreFloatNumbers { get; set; }
}