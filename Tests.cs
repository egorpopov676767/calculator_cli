using NUnit.Framework;

namespace CalculatorCLI;

[TestFixture]
public class CalculatorTests
{
    static string GetOutputOfProgram(string args)
    {
        var sw = new StringWriter();
        var consoleOut = Console.Out;
        Console.SetOut(sw);
        Program.ProcessCommand(args.Split(' '));
        Console.SetOut(consoleOut);
        return sw.ToString();
    }

    [Test]
    public void Add()
    {
        var args = "add 1 2 7 8";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("18"));
    }

    [Test]
    public void AddEven()
    {
        var args = "add even 1 2 7 8";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("10"));
    }

    [Test]
    public void AddOdd()
    {
        var args = "add odd 1 2 7 8";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("8"));
    }

    [Test]
    public void AddEmpty()
    {
        var args = "add";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void AddFloat()
    {
        var args = "add -f 1 2,5 9898 -5,66788";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("9895,83212"));
    }

    [Test]
    public void AddBadArgs()
    {
        var args = "add 12 34 ab 567 c";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("Некорректное значение: ab" + "Некорректное значение: c" + "613"));
    }

    [Test]
    public void AddHuge()
    {
        var args = "add 12471948 32695375825320 21365189021395712350829365907 " +
                   "378257012031256138962986579216352196351793659216531387095792";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("378257012031256138962986579216373561540815054961577604758967"));
    }

    [Test]
    public void Mul()
    {
        var args = "mul 1 7 9 8";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("504"));
    }

    [Test]
    public void MulEven()
    {
        var args = "mul even 1 7 9 8";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("8"));
    }

    [Test]
    public void MulOdd()
    {
        var args = "mul odd 1 7 9 8";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("63"));
    }

    [Test]
    public void MulEmpty()
    {
        var args = "mul";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void MulFloat()
    {
        var args = "mul -f 1 2,5 9898 -5,66788";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("-140251,6906"));
    }

    [Test]
    public void MulHuge()
    {
        var args = "mul 246247 86920253823664 132531626 " +
                   "392589385238502930264365";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("1113653313093859141546470545341923885239246186069920"));
    }

    [Test]
    public void Sub()
    {
        var args = "sub 10 7 9 10";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("-16"));
    }

    [Test]
    public void SubEven()
    {
        var args = "sub even 10 7 9 10";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("0"));
    }

    [Test]
    public void SubOdd()
    {
        var args = "sub odd 10 7 9 10";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("-2"));
    }

    [Test]
    public void Div()
    {
        var args = "div 1000 9 5 -3";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("-7"));
    }

    [Test]
    public void DivEven()
    {
        var args = "div even 1000 9 5 -3";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("1000"));
    }

    [Test]
    public void DivOdd()
    {
        var args = "div odd 1000 99 5 -3";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("-6"));
    }

    [Test]
    public void DivByZero()
    {
        var args = "div 1000 99 5 -3 0 10";
        var result = GetOutputOfProgram(args).Replace("\r\n", "");
        Assert.That(result, Is.EqualTo("Деление на ноль запрещено" + "0"));
    }
}