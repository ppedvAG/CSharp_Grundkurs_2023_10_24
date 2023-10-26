using System.Runtime.CompilerServices;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch();
		m.Name = "Max Mustermann";
		m.Job = "Softwareentwickler";
		m.Gehalt = 5000;

		m.Lohnauszahlung();
        Console.WriteLine(m.Jahresgehalt());
        Console.WriteLine(m.LohnProStunde(m.Gehalt));

		//Variable vom Interfacetyp
		IArbeit x = m;
		x.Lohnauszahlung();

		//IEnumerable
		//Bietet die Basis von allen Listentypen in C#
		//Von diesem Interface kann eine Variable erstellt werden um dort verschiedene Typen anzuhängen
		//z.B. Array, List, Dictionary, Stack, Queue, HashSet, ...
		IEnumerable<int> arr = new int[10];
		IEnumerable<int> list = new List<int>();
		IEnumerable<int> queue = new Queue<int>();

		VerarbeiteCollection(arr);
		VerarbeiteCollection(list);
		VerarbeiteCollection(queue);
    }

	public static void VerarbeiteCollection(IEnumerable<int> x) { }
}

public class Lebewesen { }

public class Mensch : Lebewesen, IArbeit
{
	public string Name { get; set; }

	public string Job { get; set; }

	public int Gehalt { get; set; }

	public void Lohnauszahlung()
	{
        Console.WriteLine($"Die Person {Name} arbeitet als {Job} und verdient {Gehalt}€ pro Monat.");
    }

	public int Jahresgehalt()
	{
		return Gehalt * 12;
	}

	public double LohnProStunde(int lohn)
	{
		return lohn / (IArbeit.Wochenstunden * 4.0);
	}
}

public class Hund : Lebewesen { }

/// <summary>
/// Interfaces definieren nur eine Struktur wie eine abstrakte Klasse
/// Anders als bei einer Klasse, können mehrere Interfaces vererbt werden
/// Alle Member die im Interface definiert sind, müssen von den Klassen ausimplementiert werden
/// Anwendungszweck: Polymorphismus
/// </summary>
public interface IArbeit //Interfaces fangen per Konvention mit einem I an
{
	//Durch readonly effektiv eine Konstante
	//readonly: Kann nur im Konstruktor oder bei der Variable direkt beschrieben werden
	public readonly static int Wochenstunden = 40;

	public string Job { get; set; }

	public int Gehalt { get; set; }

	void Lohnauszahlung();

	int Jahresgehalt();

	double LohnProStunde(int lohn);

	public void Test()
	{
		//Bad Practice
	}
}