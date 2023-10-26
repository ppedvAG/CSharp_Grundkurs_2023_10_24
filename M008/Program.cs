using System.Xml.Linq;

namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(30, "Max");
		m.Alter = 30; //Alter wurde an Mensch vererbt

		//Jetzt sind alle Untertypen von Lebewesen mit einer Variable vom Typ Lebewesen kompatibel
		Lebewesen lw = new Mensch(30, "Max");
		Lebewesen lw2 = new Hund(10);
		Lebewesen lw3 = new Lebewesen(10);

		m.Bewegen(10); //Das Lebewesen hat sich um 10m bewegt.
		m.Bewegen(10); //Nach Überschreibung mittels override: Der Mensch namens Max bewegt sich um 10m.
        //Ab hier kommt zweimal der selbe Output

        //Jede Klasse in C# hat die Oberklasse object
        //Ist bei jeder Klasse als Oberklasse definiert, aber nicht sichtbar

		//Hier wird die Basisimplementation in der Object Klasse verwendet
        Console.WriteLine(m.ToString()); //M008.Mensch
        Console.WriteLine(lw2.ToString()); //M008.Hund
        Console.WriteLine(lw3.ToString()); //M008.Lebewesen

        Console.WriteLine(m); //Hier wird automatisch ToString() ausgeführt
    }
}

/// <summary>
/// Basisklasse/Oberklasse
/// Hier werden verschiedene Eigenschaften definiert, die danach an die Unterklassen weitergegeben werden
/// Lebewesen ist hier ein Oberbegriff, Unterklassen: Mensch, Hund, Katze, ...
/// </summary>
public class Lebewesen
{
	public int Alter { get; set; } //Alter wird an alle Unterklassen weitergegeben

	public Lebewesen(int alter) //Konstruktor wird in den Unterklassen erzwungen
	{
		Alter = alter;
	}

	/// <summary>
	/// virtual: Stellt eine Basisimplementation dar, kann in den Unterklassen überschrieben werden
	/// </summary>
	public virtual void Bewegen(int distanz)
	{
        Console.WriteLine($"Das Lebewesen hat sich um {distanz}m bewegt.");
    }

	/// <summary>
	/// ToString() von Object wird hier weitervererbt und kann hier überschrieben werden
	/// Diese Implementation wird auch von den Unterklassen (Mensch, Hund) übernommen, solange diese Klassen keine eigene Implementation haben
	/// </summary>
	public override sealed string ToString() //Durch sealed dürfen die Unterklassen die Methode nicht weiter überschreiben
	{
		string vonOben = base.ToString(); //Holt den Text von der Oberklasse (Object)
		return $"{vonOben} ist {Alter} Jahre alt.";
	}
}

/// <summary>
/// Durch : <Klassenname> kann eine Vererbung erstellt werden
/// Mensch hat jetzt die Oberklasse Lebewesen
/// 
/// sealed: Weitervererbung verhindern
/// </summary>
public sealed class Mensch : Lebewesen
{
	public string Name { get; set; }

	//Strg + . -> Generate constructor
	//base: Greife in die Oberklasse, ähnlich wie this
	public Mensch(int alter, string name) : base(alter) //Hier Verkettung mit base
	{
		Name = name; //Beim generierten Konstruktor einfach weitere Felder hinzufügen
	}

	/// <summary>
	/// override + Abstand: Methodenvorschläge holen, Methode generieren lassen
	/// </summary>
	public override void Bewegen(int distanz)
	{
        //base.Bewegen(distanz); //Dieses Statement führt die Implementation der Oberklasse aus
        Console.WriteLine($"Der Mensch namens {Name} bewegt sich um {distanz}m.");
    }
}

//public class Kind : Mensch { }

public class Hund : Lebewesen
{
	public Mensch Besitzer { get; set; }

	public Hund(int alter) : base(alter)
	{

	}

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Der Hund mit dem Besitzer namens {Besitzer.Name} bewegt sich um {distanz}m.");
	}
}