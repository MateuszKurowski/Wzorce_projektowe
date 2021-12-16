using System;
using System.Collections.Generic;

public interface ICity
{
    void Accept(IVisitor visitor);
}

public class PolishCity : ICity
{
    public string City;

    public PolishCity(string city) => City = city;
    public void Accept(IVisitor visitor) => visitor.Visit(this);

}

public class NetherlandCity : ICity
{
    public string City;

    public NetherlandCity(string city) => City = city;

    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class USACity : ICity
{
    public string City;

    public USACity(string city) => City = city;
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public interface IVisitor
{
    void Visit(USACity element);
    void Visit(NetherlandCity netherlandCity);
    void Visit(PolishCity polishCity);
}

internal class Visitor : IVisitor
{
    private int _uSACounter = 0;
    private int _polishCounter = 0;
    private int _netherlandCounter = 0;

    public void Visit(PolishCity element)
    {
        Console.WriteLine($"Odwiedzam {element.City}");
        _polishCounter++;
    }

    public void Visit(NetherlandCity element)
    {
        Console.WriteLine($"Odwiedzam {element.City}");
        _netherlandCounter++;
    }

    public void Visit(USACity element)
    {
        Console.WriteLine($"Odwiedzam {element.City}");
        _uSACounter++;
    }

    public void PrintInfo() => Console.WriteLine($"Byłem w {_polishCounter} Polskich miastach," +
            $" {_netherlandCounter} Holenderskich miastach i {_uSACounter} miastach USA.");
}

public static class Client
{
    public static void ClientCode(List<ICity> components, IVisitor visitor)
    {
        foreach (var component in components)
        {
            component.Accept(visitor);
        }
    }

}

internal static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var components = new List<ICity>{
                new PolishCity("Kraków"),
                new PolishCity("Szczecin"),
                new PolishCity("Rzeszów"),
                new PolishCity("Gdańsk"),
                new PolishCity("Katowice"),
                new NetherlandCity("Maastricht"),
                new NetherlandCity("Amsterdam"),
                new USACity("Nowy Jork"),
                new USACity("Waszyngton"),
                new USACity("Boston"),
                new USACity("Princeton"),
                new USACity("Seattle"),
                new USACity("Chicago"),
                new USACity("Huston"),
        };

        var visitor = new Visitor();
        Client.ClientCode(components, visitor);
        visitor.PrintInfo();
    }
}

