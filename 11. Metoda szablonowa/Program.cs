using System;

internal abstract class ZamowienieTemplatka
{
    protected static bool _czyGratis;

    abstract public void DoKoszyk();
    abstract public void DoDostawa();
    abstract public void DoPlatnosc();
    protected static void DodanieGratisu() => Console.WriteLine("Dodano gratis...");
    public void PrzetwarzajZamowienie(bool czyGratis) => _czyGratis = czyGratis;
}

internal class ZamowienieStacjonarne : ZamowienieTemplatka
{
    override public void DoKoszyk() => Console.WriteLine("Wybranie produktów...");

    override public void DoPlatnosc()
    {
        Console.WriteLine("Płatność w kasie (karta/gotówka)...");
        if (_czyGratis)
            DodanieGratisu();
    }

    override public void DoDostawa() => Console.WriteLine("Wydanie produktów (odbiór osobisty)...");
}

internal class ZamowienieOnline : ZamowienieTemplatka
{
    override public void DoKoszyk()
    {
        Console.WriteLine("Kompletowanie zamówienia...");
        Console.WriteLine("Ustawiono parametry wysyłki...");
    }

    override public void DoPlatnosc()
    {
        Console.WriteLine("Płatność...");
        if (_czyGratis)
            DodanieGratisu();
    }

    override public void DoDostawa() => Console.WriteLine("Wysyłka...");
}

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ZamowienieTemplatka zamowienieOnline = new ZamowienieOnline();
        zamowienieOnline.PrzetwarzajZamowienie(true);
        zamowienieOnline.DoKoszyk();
        zamowienieOnline.DoPlatnosc();
        zamowienieOnline.DoDostawa();

        Console.WriteLine();

        ZamowienieTemplatka zamowienieStacjonarne = new ZamowienieStacjonarne();
        zamowienieStacjonarne.PrzetwarzajZamowienie(false);
        zamowienieStacjonarne.DoKoszyk();
        zamowienieStacjonarne.DoPlatnosc();
        zamowienieStacjonarne.DoDostawa();
    }
}