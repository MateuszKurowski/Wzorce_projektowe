using System;

public interface ISkokTyp
{
    void Skok();
}

public interface IKopniecieTyp
{
    void Kopniecie();
}

public abstract class Zawodnik
{
    private IKopniecieTyp _kopniecieTyp;
    private ISkokTyp _skokTyp;

    public Zawodnik(IKopniecieTyp kopniecieTyp, ISkokTyp skokTyp)
    {
        _kopniecieTyp = kopniecieTyp;
        _skokTyp = skokTyp;
    }

    public static void Uderzenie() => Console.WriteLine("Uderzenie");

    public void Kopniecie() => _kopniecieTyp.Kopniecie();

    public void Skok() => _skokTyp.Skok();

    public void UstawKopniecieTyp(IKopniecieTyp kopniecieTyp) => _kopniecieTyp = kopniecieTyp;

    public void UstawSkokTyp(ISkokTyp skokTyp) => _skokTyp = skokTyp;

    public abstract void Przedstaw();

}

internal class KopniecieLod : IKopniecieTyp
{
    public void Kopniecie() => Console.WriteLine("Kopnięcie lodowe");
}

internal class KopniecieOgien : IKopniecieTyp
{
    public void Kopniecie() => Console.WriteLine("Kopnięcie z ogniem");
}

internal class KrotkiSkok : ISkokTyp
{
    public void Skok() => Console.WriteLine("Krótki skok");
}

internal class DlugiSkok : ISkokTyp
{
    public void Skok() => Console.WriteLine("Długi skok");
}

public class SubZero : Zawodnik
{
    public SubZero(IKopniecieTyp kopniecieTyp, ISkokTyp skokTyp) : base(kopniecieTyp, skokTyp) { }

    public override void Przedstaw() => Console.WriteLine("Jestem Sub-Zero!");
}

public class Scorpion : Zawodnik
{
    public Scorpion(IKopniecieTyp kopniecieTyp, ISkokTyp skokTyp) : base(kopniecieTyp, skokTyp) { }

    public override void Przedstaw() => Console.WriteLine("Jestem Scorpion!");
}

internal static class MainClass
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("-- Mortal Kombat --");
        Console.WriteLine();

        ISkokTyp krotkiSkok = new KrotkiSkok();
        ISkokTyp dlugiSkok = new DlugiSkok();
        IKopniecieTyp kopniecieLod = new KopniecieLod();
        IKopniecieTyp kopniecieOgien = new KopniecieOgien();

        Zawodnik subZero = new SubZero(kopniecieLod, krotkiSkok);
        subZero.Przedstaw();
        Zawodnik.Uderzenie();
        subZero.Kopniecie();
        subZero.Skok();
        subZero.UstawSkokTyp(dlugiSkok);
        subZero.Skok();
        Console.WriteLine();

        Zawodnik scoripion = new Scorpion(kopniecieOgien, dlugiSkok);
        scoripion.Przedstaw();
        Zawodnik.Uderzenie();
        scoripion.Kopniecie();
        scoripion.UstawKopniecieTyp(kopniecieLod);
        scoripion.Kopniecie();
        scoripion.Skok();
    }
}