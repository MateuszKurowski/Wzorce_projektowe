using System;

internal interface IStan
{
    void Alert();
}

internal class Powiadomienia
{
    private IStan _aktualnyStan;

    public Powiadomienia() => _aktualnyStan = new Wibracja();
    public void UstawStan(IStan stan)
    {
        if(stan.ToString() == new Wibracja().ToString())
            Console.WriteLine("wyciszenie...");
        _aktualnyStan = stan;
    }

    public void Alert() => _aktualnyStan.Alert();
}

internal class Dzwonek : IStan
{
    public void Alert() => Console.WriteLine("dzwonek...");
}

internal class Wibracja : IStan
{
    public void Alert() => Console.WriteLine("wibracja...");
}

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var powiadomienia = new Powiadomienia();
        powiadomienia.Alert();
        powiadomienia.UstawStan(new Dzwonek());
        powiadomienia.Alert();
        powiadomienia.UstawStan(new Wibracja());
        powiadomienia.UstawStan(new Wibracja());
        powiadomienia.Alert();
    }
}