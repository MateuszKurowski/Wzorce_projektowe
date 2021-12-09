using System;
using System.Collections.Generic;

class Zycie
{
    private string _czas;

    public void Set(string czas)
    {
        _czas =  czas;
        Console.WriteLine("Skok do roku: " + _czas);
    }

    public Pamiatka ZapiszPamiatke()
    {
        Console.WriteLine("stan zapisany");
        return new Pamiatka(_czas);
    }

    public static void PrzywrocPamiatke(Pamiatka pamiatka) => Console.WriteLine("Przywrócono rok: " + pamiatka.PobierzCzas());

    public class Pamiatka
    {
        private readonly string _czas;

        public Pamiatka(string czas) => _czas = czas;

        public string PobierzCzas() => _czas;
    }
}

static class MainClass
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Powrót do przyszłosci (Back to the Future)");
        Console.WriteLine();

        var zapisaneStany = new List<Zycie.Pamiatka>();
        var zycie = new Zycie();

        zycie.Set("1985");
        zapisaneStany.Add(zycie.ZapiszPamiatke());
        zycie.Set("1955");
        zapisaneStany.Add(zycie.ZapiszPamiatke());
        zycie.Set("2015");
        zapisaneStany.Add(zycie.ZapiszPamiatke());
        zycie.Set("1885");

        Zycie.PrzywrocPamiatke(zapisaneStany[0]);
    }
}