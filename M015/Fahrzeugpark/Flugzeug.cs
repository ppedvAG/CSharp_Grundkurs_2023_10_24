using System;

namespace Fahrzeugpark;

public class Flugzeug : Fahrzeug
{
	public int MaxH { get; set; }

    public Flugzeug(string name, int maxV, double preis, int maxH) : base(name, maxV, preis)
	{
		MaxH = maxH;
	}

	public override string Info()
	{
		return base.Info() + $" Die maximale Flughöhe beträgt {MaxH}m.";
	}

	public override void Hupen()
	{
        Console.WriteLine("3");
    }
}