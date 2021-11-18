using System;
using System.IO;
using System.Runtime;
using System.Text;

public interface ITelewizor
{
	int Kanal { get; set; }
	void Wlacz();
	void Wylacz();
	void ZmienKanal(int kanal);
}

public class TvLg : ITelewizor
{
	public TvLg()
	{
		this.Kanal = 1;
	}

	public int Kanal { get; set; }

	public void Wlacz()
	{
		Console.WriteLine("Telewizor LG włączony.");
	}

	public void Wylacz()
	{
		Console.WriteLine("Telewizor LG wyłączony.");
	}

	public void ZmienKanal(int kanal)
	{
		this.Kanal = kanal;
		Console.WriteLine($"Telewizor LG, kanał: {kanal}");
	}
}



public class TvXiaomi : ITelewizor
{

	public TvXiaomi()
	{
		this.Kanal = 1;
	}

	public int Kanal { get; set; }

	public void Wlacz()
	{
		Console.WriteLine("Telewizor Xiaomi włączony.");
	}

	public void Wylacz()
	{
		Console.WriteLine("Telewizor Xiaomi wyłączony.");
	}

	public void ZmienKanal(int kanal)
	{
		this.Kanal = kanal;
		Console.WriteLine($"Telewizor Xiaomi, kanał: {kanal}");
	}

}

public abstract class PilotAbstrakcyjny
{
	private readonly ITelewizor tv;

	public PilotAbstrakcyjny(ITelewizor tv)
	{
		this.tv = tv;
	}

	public void Wlacz()
	{
		tv.Wlacz();
	}

	public void Wylacz()
	{
		tv.Wylacz();
	}

	public void ZmienKanal(int kanal)
	{
		tv.ZmienKanal(kanal);
	}
}

public class PilotHarmony : PilotAbstrakcyjny
{
	public PilotHarmony(ITelewizor tv) : base(tv) { }

	public void DoWlacz()
	{
		Console.WriteLine("Pilot Harmony włącza telewizor...");
        Wlacz();
	}

	public void DoWylacz()
	{
		Console.WriteLine("Pilot Harmony wyłącza telewizor...");
        Wylacz();
    }

	public void DoZmienKanal(int kanal)
	{
		Console.WriteLine("Pilot Harmony zmienia kanał...");
		ZmienKanal(kanal);
	}
}

public class PilotPhilips : PilotAbstrakcyjny
{
	public PilotPhilips(ITelewizor tv) : base(tv) { }

	public void DoWlacz()
	{
		Console.WriteLine("Pilot Philips włącza telewizor...");
        Wlacz();
    }

	public void DoWylacz()
	{
		Console.WriteLine("Pilot Philips wyłącza telewizor...");
        Wylacz();
    }

	public void DoZmienKanal(int kanal)
	{
		Console.WriteLine("Pilot Philips zmienia kanał...");
		ZmienKanal(kanal);
	}
}

class MainClass
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;
		ITelewizor tv = new TvLg();
		PilotHarmony pilotHarmony = new PilotHarmony(tv);
		PilotPhilips pilotPhilips = new PilotPhilips(tv);

		pilotHarmony.DoWlacz();
		Console.WriteLine("Kanał: " + tv.Kanal);
		pilotPhilips.DoZmienKanal(100);
		Console.WriteLine("Kanał: " + tv.Kanal);
		pilotHarmony.DoWylacz();
	}
}