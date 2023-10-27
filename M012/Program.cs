namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		List<int> ints = Enumerable.Range(1, 20).ToList();
		
		//Finde alle geraden Zahlen
		//Ohne Linq
		foreach (int i in ints)
			if (i % 2 == 0)
				Console.WriteLine(i);

		//Mit Linq
		IEnumerable<int> x = ints.Where(e => e % 2 == 0); //Selbes Ergebnis
		//Where Funktion macht im Hintergrund eine Schleife und eine if

		//IEnumerable
		//Nur eine Anleitung, die bei Ausiterierung die fertige Liste erzeugt
		//Mit foreach, ToList(), ToArray(), ... können die konkreten Werte erzeugt werden
		Enumerable.Range(1, 1_000_000_000); //1ms (nur eine Anleitung)
		//Enumerable.Range(1, 1_000_000_000).ToList(); //7s (hier werden konkrete Werte erzeugt)

        Console.WriteLine(ints.Average());
        Console.WriteLine(ints.Sum());
        Console.WriteLine(ints.Min());
        Console.WriteLine(ints.Max());

        Console.WriteLine(ints.First()); //1
        Console.WriteLine(ints.FirstOrDefault()); //1

        //Console.WriteLine(ints.First(e => e % 50 == 0)); //Bei First kann auch eine Bedingung angegeben werden
        Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0));
		//First() wirft eine Exception, wenn anhand der Bedingung kein Element gefunden wird
		//FirstOrDefault() gibt einfach den Standardwert des Typens der Collection zurück (int: 0, string: null, bool: false, Fahrzeug: null, ...)
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Alte Linq Schreibweise, seit 2007 am Ende
		List<Fahrzeug> bmwsLinqAlt = (from f in fahrzeuge
									  where f.Marke == FahrzeugMarke.BMW
									  select f).ToList();

		//Methodenketten
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion
	}
}

public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }