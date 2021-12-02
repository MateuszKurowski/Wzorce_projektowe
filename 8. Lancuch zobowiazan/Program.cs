using System;

public interface Lancuch
{
    void UstawNastepne(Lancuch c);
    void Przetwarzaj(Powiadomienia powiadomienia);
}

public class Powiadomienia
{
    private readonly int _number;

    public Powiadomienia(int number) => _number = number;

    public int PobierzLiczbe() => _number;
}

public class BrakLancuch : Lancuch
{
    private Lancuch _nastepneWLancuchu;

    public void UstawNastepne(Lancuch c) => _nastepneWLancuchu = c;

    public void Przetwarzaj(Powiadomienia powiadomienia)
    {
        if (powiadomienia.PobierzLiczbe() <= 0)
            Console.WriteLine("Brak powiadomień");
        else
            _nastepneWLancuchu.Przetwarzaj(powiadomienia);
    }
}

public class MaloLancuch : Lancuch
{
    private Lancuch _nastepneWLancuchu;

    public void UstawNastepne(Lancuch c) => _nastepneWLancuchu = c;

    public void Przetwarzaj(Powiadomienia powiadomienia)
    {
        if (powiadomienia.PobierzLiczbe() <= 5)
            Console.WriteLine($"Mało powiadomień: {powiadomienia.PobierzLiczbe()}");
        else
            _nastepneWLancuchu.Przetwarzaj(powiadomienia);
    }
}

public class DuzoLancuch : Lancuch
{
    private Lancuch _nastepneWLancuchu;

    public void UstawNastepne(Lancuch c) => _nastepneWLancuchu = c;

    public void Przetwarzaj(Powiadomienia powiadomienia) => Console.WriteLine($"Dużo powiadomień: {powiadomienia.PobierzLiczbe()}");
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Lancuch l1 = new BrakLancuch();
        Lancuch l2 = new MaloLancuch();
        Lancuch l3 = new DuzoLancuch();
        l1.UstawNastepne(l2);
        l2.UstawNastepne(l3);

        var i = 0;
        l1.Przetwarzaj(new Powiadomienia(i));
        i++;
        l1.Przetwarzaj(new Powiadomienia(i));
        i += 11;
        l1.Przetwarzaj(new Powiadomienia(i));
        i -= 9;
        l1.Przetwarzaj(new Powiadomienia(i));
        i -= 3;
        l1.Przetwarzaj(new Powiadomienia(i));
    }
}