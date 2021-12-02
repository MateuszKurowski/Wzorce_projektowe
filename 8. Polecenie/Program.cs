using System;

public interface IPolecenie
{
    void Wykonaj();
}

public class KomendaWlacz : IPolecenie
{
    private readonly Lampa _lampa;
    public KomendaWlacz(Lampa lampa) => _lampa = lampa;
    public void Wykonaj() => _lampa.Wlacz();
}

public class KomendaWylacz : IPolecenie
{
    private readonly Lampa _lampa;
    public KomendaWylacz(Lampa lampa) => _lampa = lampa;
    public void Wykonaj() => _lampa.Wylacz();
}

public class Lampa
{
    private bool _stan;

    public void Wlacz() => _stan = true;

    public void Wylacz() => _stan = false;

    public bool Sprawdz() => _stan;
}

public class Pilot
{
    private IPolecenie _polecenie;

    public void UstawPolecenie(IPolecenie polecenie) => _polecenie = polecenie;

    public void WcisnijGuzik() => _polecenie.Wykonaj();
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var lampa = new Lampa();

        IPolecenie wlacz = new KomendaWlacz(lampa);
        IPolecenie wylacz = new KomendaWylacz(lampa);
        var pilot = new Pilot();

        Console.WriteLine(lampa.Sprawdz() ? "Lampa włączona" : "Lampa wyłączona");

        pilot.UstawPolecenie(wlacz);
        pilot.WcisnijGuzik();
        Console.WriteLine(lampa.Sprawdz() ? "Lampa włączona" : "Lampa wyłączona");

        pilot.UstawPolecenie(wylacz);
        pilot.WcisnijGuzik();
        Console.WriteLine(lampa.Sprawdz() ? "Lampa włączona" : "Lampa wyłączona");
    }
}