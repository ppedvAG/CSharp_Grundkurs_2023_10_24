using System;

namespace Fahrzeugpark;

public class Schiff : Fahrzeug, IBeladbar
{
	public string Treibstoff { get; set; }

	public Fahrzeug Ladung { get; set; }

	public Schiff(string name, int maxV, double preis, string treibstoff) : base(name, maxV, preis)
	{
		Treibstoff = treibstoff;
	}

	public override string Info()
	{
		return base.Info() + $" Es fährt mit {Treibstoff}." +
		   (Ladung != null ? $" Es hat {Ladung.Name} aufgeladen." : "");
	}

	public override void Hupen()
	{
        Console.WriteLine("2");
    }

	public void Belade(Fahrzeug fzg)
	{
		if (Ladung == null)
			Ladung = fzg;
		else
            Console.WriteLine($"Schiff ist bereits beladen mit {Ladung.Name}");
    }

	public Fahrzeug Entlade()
	{
		if (Ladung == null)
		{
            Console.WriteLine("Es ist kein Fahrzeug aufgeladen");
            return null;
		}

		Fahrzeug f = Ladung;
		Ladung = null;
		return f;
	}
}
