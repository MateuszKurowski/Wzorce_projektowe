using System;
using System.Collections.Generic;
using System.Text;

public interface Kompozyt
{
    string Nazwa { get; set; }
    void Renderuj();
    void DodajElement(Kompozyt element);
    void UsunElement(Kompozyt element);
}

public class Lisc : Kompozyt
{
    public string Nazwa { get; set; }

    public void Renderuj()
    {
        Console.WriteLine(Nazwa + " renderowanie...");
    }

    public void DodajElement(Kompozyt element) { }

    public void UsunElement(Kompozyt element) { }
}


public class Wezel : Kompozyt
{
    private List<Kompozyt> Lista = new List<Kompozyt>();

    public string Nazwa { get; set; }

    public void Renderuj()
    {
        Console.WriteLine($"{Nazwa} rozpoczęcie renderowania");

        foreach (var item in Lista)
        {
            item.Renderuj();
        }

        Console.WriteLine($"{Nazwa} zakończenie renderowania");
    }

    public void DodajElement(Kompozyt element)
    {
        Lista.Add(element);
    }

    public void UsunElement(Kompozyt element)
    {
        Lista.Remove(element);
    }
}


class MainClass
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Wezel korzen = new Wezel();
        korzen.Nazwa = "Korzeń";

        Lisc lisc11 = new Lisc();
        lisc11.Nazwa = "Liść 1.1";
        korzen.DodajElement(lisc11);

        Wezel wezel2 = new Wezel();
        wezel2.Nazwa = "Węzeł 2";

        Lisc lisc21 = new Lisc();
        lisc21.Nazwa = "Liść 2.1";
        wezel2.DodajElement(lisc21);

        Lisc lisc22 = new Lisc();
        lisc22.Nazwa = "Liść 2.2";
        wezel2.DodajElement(lisc22);

        Lisc lisc23 = new Lisc();
        lisc23.Nazwa = "Liść 2.3";
        wezel2.DodajElement(lisc23);

        korzen.DodajElement(wezel2);

        Wezel wezel3 = new Wezel();
        wezel3.Nazwa = "Węzeł 3";

        Lisc lisc31 = new Lisc();
        lisc31.Nazwa = "Liść 3.1";
        wezel3.DodajElement(lisc31);

        Lisc lisc32 = new Lisc();
        lisc32.Nazwa = "Liść 3.2";
        wezel3.DodajElement(lisc32);

        Wezel wezel33 = new Wezel();
        wezel33.Nazwa = "Węzeł 3.3";

        Lisc lisc331 = new Lisc();
        lisc331.Nazwa = "Liść 3.3.1";
        wezel33.DodajElement(lisc331);
        wezel3.DodajElement(wezel33);

        korzen.DodajElement(wezel3);

        korzen.Renderuj();
    }
}