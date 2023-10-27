using System;

namespace Fahrzeugpark;

public abstract class Fahrzeug
{
	public string Name { get; set; }

	public int MaxV { get; set; }

	public int AktV { get; set; }

	public double Preis { get; set; }

	public bool MotorAn { get; set; }

	public Fahrzeug(string name, int maxV, double preis)
	{
		Name = name;
		MaxV = maxV;
		Preis = preis;
	}

    public void StarteMotor()
	{
		if (!MotorAn)
		{
			MotorAn = true;
			Console.WriteLine($"Motor von {Name} wurde gestartet");
		}
		else
			Console.WriteLine("Motor läuft bereits");
	}

	public void StoppeMotor()
	{
		if (MotorAn)
		{
			if (AktV == 0)
			{
				MotorAn = false;
				Console.WriteLine($"Motor von {Name} wurde gestoppt");
			}
			else
				Console.WriteLine("Das Fahrzeug fährt noch");
		}
		else
			Console.WriteLine("Motor läuft noch nicht");
	}

	public void Beschleunige(int a)
	{
		if (!MotorAn)
		{
			Console.WriteLine("Der Motor läuft nicht");
			return;
		}

		if (AktV + a > MaxV)
		{
			Console.WriteLine($"Fahrzeug kann nicht schneller als {MaxV}km/h fahren. (Neue Geschwindigkeit wäre {AktV + a})");
			return;
		}

		if (AktV + a < 0)
		{
			Console.WriteLine("Das Fahrzeug kann nicht unter 0km/h bremsen.");
			return;
		}

		AktV += a;
		Console.WriteLine($"Das Fahrzeug beschleunigt auf {AktV}km/h.");
	}

	public virtual string Info()
	{
		return $"Das Fahrzeug {Name} {(AktV > 0 ? $"fährt momentan {AktV}km/h und " : "")}kann maximal {MaxV}km/h fahren und kostet {Preis}.";
	}

	public static Fahrzeug GeneriereFahrzeug(string nameSuffix = "")
	{
		Random r = new Random();
		int x = r.Next(0, 3);
		switch (x)
		{
			case 0: return new PKW("VW" + nameSuffix, 200, 20000, 5);
			case 1: return new Schiff("Titanic" + nameSuffix, 40, 20_000_000, "Dampf");
			default: return new Flugzeug("Boeing" + nameSuffix, 1000, 15_000_000, 12_000);
		}
	}

	public override string ToString()
	{
		return $"{GetType().Name}: {Name}";
	}

	public abstract void Hupen();
}