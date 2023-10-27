namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generische Typargumente (Generics)
		//Stellen einen dynamischen Typen dar, der im C# Skript mit einem fixen Typen gesetzt werden kann
		//Dieser Typ wird im Skript aber nur als Platzhalter für einen Typen angelegt
		//Werden mit T abgekürzt

		//List
		//Klasse, die mehrere Werte halten (wie Array) aber flexibel ist von der Größe her (nicht wie Array)
		//Die Klasse List hat ein Array darunter, welches mit Größe 4 startet und bei dem die Größe verdoppelt wird, wenn das 5. Element hinzugefügt wird
		List<int> list = new List<int>(); //T ist hier int
		list.Add(0); //T wurde hier zu int
		list.Add(1);
		list.Add(2);
		list.Add(3);
		list.Add(4); //Ab hier wird int[4] zu int[8]

		List<string> str = new List<string>(); //T ist hier string
		str.Add("a"); //T wurde hier zu string

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>(); //T ist hier Fahrzeug
		fahrzeuge.Add(new Fahrzeug());
		fahrzeuge.Add(new Fahrzeug());
		fahrzeuge.Add(new Fahrzeug());

        Console.WriteLine(list.Count); //Gibt die Anzahl der Elemente zurück (= array.Length)

		foreach (int i in list) //foreach genau wie bei Array
            Console.WriteLine(i);

		Console.WriteLine(list[0]); //Index genau wie bei Array

		list.Clear(); //Entleert die Liste

		list.Sort(); //Sortiert die Liste (nicht sinnvoll bei Objekt Listen)

		list.Contains(3); //Ist ein Element enthalten?

		//Dictionary
		//Liste von Schlüssel-Wert Paaren
		//Enthält Schlüssel, die alle jeweils einen Wert angehängt haben
		//Schlüssel müssen eindeutig sein

		Dictionary<string, int> einwohnerzahlen = new(); //new(): Ergänzt den Typen von Links
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000); //3 Schlüssel, zu jedem Schlüssel ein Wert
		//einwohnerzahlen.Add("Paris", 2_160_000); //Nicht möglich, da Schlüssel bereits existiert

		if (einwohnerzahlen.ContainsKey("Salzburg")) //Prüfe ob ein Key existiert
			Console.WriteLine(einwohnerzahlen["Salzburg"]); //Dictionary angreifen wie bei List aber mit einem Index der dem Typ des Schlüssels entspricht

        Console.WriteLine(einwohnerzahlen.Count);

		//var: Der Compiler ergänzt hier den Typen automatisch anhand des Inhalts der Liste
		//var -> Strg + .: Typ ergänzen
		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //kv enthält Schlüssel und Wert getrennt voneinander
		{
            Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
        }
    }
}

public class Fahrzeug { }