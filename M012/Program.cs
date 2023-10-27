using System.Diagnostics;
using System.Net.Http.Headers;

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

		#region Linq mit Objektliste
		//Alle Fahrzeuge finden die mehr als 200km/h Höchstgeschwindigkeit haben
		fahrzeuge.Where(e => e.MaxV > 200); //Hier die Bedingung angeben -> Predicate

		//Ergebnisse anschauen
		//Breakpoint setzen -> Zeile ausführen -> Ausklappen, Results View ausklappen

		//Alle VWs finden die mehr als 200km/h Höchstgeschwindigkeit haben
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).Where(e => e.MaxV > 200); //Linq Anweisungen verketten
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV > 200); //Vereinfachung vom Zeile darüber

		//Die schnellsten Fahrzeuge finden
		fahrzeuge.OrderByDescending(e => e.MaxV); //Hier wird keine Bedingung angegeben -> Selektor
		//Bei Linq kommt immer eine neue Liste heraus
		fahrzeuge.OrderBy(e => e.Marke).ThenByDescending(e => e.MaxV); //Sekundäre Sortierung mittels ThenBy(Descending)

		//Fahren alle Fahrzeuge über 200km/h?
		fahrzeuge.All(e => e.MaxV > 200); //Ergebnis bool
		if (fahrzeuge.All(e => e.MaxV > 200))
		{

		}

		//Fährt mindestens ein Fahrzeug über 300km/h?
		fahrzeuge.Any(e => e.MaxV > 300); //Ergebnis bool
		if (fahrzeuge.Any(e => e.MaxV > 300))
		{

		}

		//Wieviele VWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW); //12 Schleifendurchläufe = 12
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).Count(); //12 Schleifendurchläufe + 4 Durchgänge = 16
        Console.WriteLine(fahrzeuge.Count);

		//Min, MinBy, Max, MaxBy, Sum, Average
		fahrzeuge.Average(e => e.MaxV); //Berechne den Durchschnitt nur der Geschwindigkeiten
		fahrzeuge.Sum(e => e.MaxV);

		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit

		fahrzeuge.Max(e => e.MaxV);	//Die größte Geschwindigkeit
		fahrzeuge.MaxBy(e => e.MaxV); //Das Fahrzeug mit der größten Geschwindigkeit

		//Die 3 schnellsten Fahrzeuge haben
		fahrzeuge
			.OrderByDescending(e => e.MaxV)
			.Take(3);

		//Skip und Take bei Webshop
		//10 Artikel pro Seite

		//Select
		//Wandelt die Liste in eine neue Form um

		//2 Anwendungsfälle
		//1. Fall (80% der Fälle): Einzelnen Feld aus der Liste entnehmen
		fahrzeuge.Select(e => e.Marke);
		fahrzeuge.Select(e => e.Marke).Distinct(); //Duplikate entfernen

		//2. Fall (20% der Fälle): Liste transformieren
		//Aus einem Ordner alle Dateien einlesen ohne Pfad und Erweiterung
		
		//Ohne Linq
		string[] pfade = Directory.GetFiles(@"C:\Windows");
		List<string> dateinamen = new List<string>();
		foreach (string pfad in pfade)
			dateinamen.Add(Path.GetFileNameWithoutExtension(pfad));

		//Mit Linq
		List<string> dateinamenLinq = Directory
			.GetFiles(@"C:\Windows") //Alle Pfade holen
			.Select(e => Path.GetFileNameWithoutExtension(e)) //Wendet auf jedes Element der Liste die entsprechende Funktion an
			.ToList(); //Liste erzeugen

        Console.WriteLine(dateinamen.SequenceEqual(dateinamenLinq));
		#endregion

		#region Erweiterungsmethoden
		int zahl = 328957;
        Console.WriteLine(zahl.Quersumme());
        Console.WriteLine(382843.Quersumme());

		//Mische die Fahrzeugliste
		fahrzeuge.Shuffle();
		#endregion

		//Durchschnitt berechnen
		double summe = 0;
		foreach (Fahrzeug f in fahrzeuge)
			summe += f.MaxV;
		Console.WriteLine(summe / fahrzeuge.Count);

		Console.WriteLine($"Die Durchschnittsgeschwindigkeit ist {fahrzeuge.Average(e => e.MaxV)}");
	}
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
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