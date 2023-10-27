using System;

namespace Fahrzeugpark;

public class PKW : Fahrzeug
{
	public int AnzSitze { get; set; }

    public PKW(string name, int maxV, double preis, int anzSitze) : base(name, maxV, preis)
	{
		AnzSitze = anzSitze;
	}

	public override string Info()
	{
		return base.Info() + $" Es hat {AnzSitze} Sitzplätze.";
	}

	public override void Hupen()
	{
        Console.WriteLine("1");
    }
}
