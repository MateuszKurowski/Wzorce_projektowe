using System;
using System.Text;

interface ILitery
{
    public string ShowAlfa();
}

interface ICyfry
{
    public string ShowNum();
}

class LacinkaLetters : ILitery
{
    string letters;

    public LacinkaLetters()
    {
        letters = "abcde";
    }
    public string ShowAlfa()
    {
        return letters;
    }
}

class LacinkaNumbers : ICyfry
{
    string numbers;

    public LacinkaNumbers()
    {
        numbers = "I II III";
    }
    public string ShowNum()
    {
        return numbers;
    }
}

class CyrylicaLetters : ILitery
{
    string letters;

    public CyrylicaLetters()
    {
        letters = "абвгд";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}

class CyrylicaNumbers : ICyfry
{
    string numbers;

    public CyrylicaNumbers()
    {
        numbers = "1 2 3";
    }

    public string ShowNum()
    {
        return numbers;
    }
}

class GrekaLetters : ILitery
{
    string letters;

    public GrekaLetters()
    {
        letters = "αβγδε";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}

class GrekaNumbers : ICyfry
{
    string numbers;

    public GrekaNumbers()
    {
        numbers = "αʹ βʹ γʹ";
    }

    public string ShowNum()
    {
        return numbers;
    }
}


abstract class SystemFactory
{
    public abstract ICyfry CreateNum();
    public abstract ILitery CreateAlfa();
}

class LacinkaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new LacinkaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new LacinkaNumbers();
    }
}

class GrekaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new GrekaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new GrekaNumbers();
    }
}

class CyrylicaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new CyrylicaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new CyrylicaNumbers();
    }
}


class AlfabetFactory
{
    private SystemFactory systemFactory;

    public ILitery alfa;
    public ICyfry numbers;

    public AlfabetFactory(SystemFactory systemFactory)
    {
        this.systemFactory = systemFactory;
    }

    public void Generate()
    {
        this.numbers = systemFactory.CreateNum();
        this.alfa = systemFactory.CreateAlfa();
    }
}


public class Application
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        AlfabetFactory alfabet;

        alfabet = new AlfabetFactory(new LacinkaFactory());
        alfabet.Generate();
        Console.Write(alfabet.alfa.ShowAlfa() + " ");
        Console.WriteLine(alfabet.numbers.ShowNum());

        alfabet = new AlfabetFactory(new CyrylicaFactory());
        alfabet.Generate();
        Console.Write(alfabet.alfa.ShowAlfa() + " ");
        Console.WriteLine(alfabet.numbers.ShowNum());

        alfabet = new AlfabetFactory(new GrekaFactory());
        alfabet.Generate();
        Console.Write(alfabet.alfa.ShowAlfa() + " ");
        Console.WriteLine(alfabet.numbers.ShowNum());
    }
}