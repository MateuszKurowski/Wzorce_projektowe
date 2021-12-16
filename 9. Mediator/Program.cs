using System;
using System.Collections.Generic;

public interface IMediator
{
    public void DodajUzytkownika(IUzytkownik uzytkownik);
    public void WyslijWiadomosc(string wiadomosc, IUzytkownik nadawca);
}

public interface IUzytkownik
{
    public void WyslijWiadomosc(string wiadomosc);
    public void OdbierzWiadomosc(string wiadomosc);
}

public class Mediator : IMediator
{
    private readonly List<IUzytkownik> _uzytkownicy;

    public Mediator() => _uzytkownicy = new List<IUzytkownik>();

    public void DodajUzytkownika(IUzytkownik uzytkownik) => _uzytkownicy.Add(uzytkownik);

    public void WyslijWiadomosc(string wiadomosc, IUzytkownik nadawca)
    {

        foreach (var item in _uzytkownicy)
        {
            if (item == nadawca)
                continue;
           item.OdbierzWiadomosc(wiadomosc);
        }
    }
}

public class Dev : IUzytkownik
{
    public string _login;
    public IMediator _mediator;

    public Dev(IMediator Mediator, string login)
    {
        _login = login;
        _mediator = Mediator;
    }

    public void WyslijWiadomosc(string wiadomosc) => _mediator.WyslijWiadomosc(wiadomosc, this);

    public void OdbierzWiadomosc(string wiadomosc) => Console.WriteLine("Programista " + _login + " otrzymał wiadomość: " + wiadomosc);
}

public class Klient : IUzytkownik
{
    public string _login;
    public IMediator _mediator;

    public Klient(IMediator Mediator, string login)
    {
        _login = login;
        _mediator = Mediator;
    }

    public void WyslijWiadomosc(string wiadomosc) => _mediator.WyslijWiadomosc(wiadomosc, this);

    public void OdbierzWiadomosc(string wiadomosc) => Console.WriteLine("Użytkownik " + _login + " otrzymał wiadomość: " + wiadomosc);
}

static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IMediator mediator = new Mediator();

        IUzytkownik ania = new Klient(mediator, "Ania");
        IUzytkownik nakamoto = new Dev(mediator, "Nakamoto");
        IUzytkownik geohot = new Dev(mediator, "Geohot");

        mediator.DodajUzytkownika(ania);
        mediator.DodajUzytkownika(nakamoto);
        mediator.DodajUzytkownika(geohot);

        ania.WyslijWiadomosc("Proszę natychmiast wprowadzić poprawki na produkcje.");
        geohot.WyslijWiadomosc("Czekam az Nakamoto zaparzy kawe...");
    }
}