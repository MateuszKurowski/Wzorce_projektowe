using System;
using System.Collections.Generic;
using System.Text;

public enum Genre
{
    Sport,
    Politics,
    Economy,
    Science
}

public interface IObserver
{
    void Update(ISubject subject);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class NewsAgency : ISubject
{
    public string NewsHeadline;
    public Genre State;

    public void setNewsHeadline(Genre state, string news)
    {
        NewsHeadline = news;
        State = state;
        Notify();
    }

    private List<IObserver> Observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this.Observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in Observers)
        {
            observer.Update(this);
        }
    }
}

class DailyEconomy : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as NewsAgency).State == Genre.Economy)
            Console.WriteLine($"DailyEconomy publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
    }
}

class NewYorkTimes : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as NewsAgency).State == Genre.Economy || (subject as NewsAgency).State == Genre.Science || (subject as NewsAgency).State == Genre.Sport)
            Console.WriteLine($"NewYorkTimes publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
    }
}

class NationalGeographic : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as NewsAgency).State == Genre.Science)
            Console.WriteLine($"NationalGeographic publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var newsAgency = new NewsAgency();

        var dailyEconomy = new DailyEconomy();
        var newYork = new NewYorkTimes();
        var nationalGeographic = new NationalGeographic();

        newsAgency.Attach(dailyEconomy);
        newsAgency.Attach(newYork);
        newsAgency.Attach(nationalGeographic);

        newsAgency.setNewsHeadline(Genre.Economy, "USA is going bancrupt!");
        newsAgency.setNewsHeadline(Genre.Science, "Life on Alpha Centauri");
        newsAgency.setNewsHeadline(Genre.Sport, "Adam Małysz is the greatest sportsman in the history of mankind");
        newsAgency.setNewsHeadline(Genre.Economy, "CD Project RED value has grown by 500% in 2020");

        newsAgency.Detach(dailyEconomy);

        newsAgency.setNewsHeadline(Genre.Science, "Kirkendall effect causing airplanes' engine deteriorate");
        newsAgency.setNewsHeadline(Genre.Economy, "Texas is going bancrupt!");
    }
}