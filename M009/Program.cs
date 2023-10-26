namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		//Polymorphismus
		//= Typkompatibilität
		//Eine Variable kann immer ihren Typen selbst halten und/oder eine Unterklasse von dem Typen

		//Typkompatibilität: Welche Typen sind mit welchen anderen Typen kompatibel?
		Mensch m = new Mensch();
		//m = new Hund(); //Nicht möglich
		Lebewesen l = new Mensch();
		Lebewesen l2 = new Hund();

		//Eine Variable vom Typ Object kann alles halten
		object o = new Mensch();
		o = 123;
		o = false;
		o = "";

		//GetType(): Gibt den Typen des Objekts, dass an der Variable hängt zurück
		//Hier bekommen wir ein Type Objekt mit weiteren Informationen
		Type menschType = m.GetType();
		Console.WriteLine(menschType);
		Console.WriteLine(menschType.FullName); //Namespace + Name
		Console.WriteLine(menschType.Name); //Name ohne Namespace

		//typeof(...): Erzeugt über einen Klassennamen ein Type Objekt
		Type menschTypeof = typeof(Mensch);
		if (menschType == menschTypeof)
		{
			//Ist der Typ vom Objekt der Variable m gleich dem Typen der Klasse Mensch?
		}

		//Genauer Typvergleich: Prüft ob die Typen genau übereinstimmen
		if (m.GetType() == typeof(Mensch))
		{
			//true
		}

		if (m.GetType() == typeof(Lebewesen))
		{
			//false
		}

		//Vererbungshierarchie Typvergleich: Mit dem is-Operator können statt genauen Vergleichen auch Vererbungshierarchien verglichen werden
		//Prüft, ob das Objekt (links) mit dem Typen rechts kompatibel ist, wenn der rechte Typ eine Variable wäre
		//Lebewesen l = m; //Das ist die is Prüfung
		if (m is Mensch)
		{
			//true
		}

		if (m is Lebewesen)
		{
			//true
		}

		if (m is object)
		{
			//immer true
		}

        Console.WriteLine(m); //Mensch
        Console.WriteLine(l); //Mensch
		Console.WriteLine(l2); //Hund
		//Hier wird der Typ des eigenlichen Objekts verwendet, dank virtual

		Lebewesen[] lebewesen = new Lebewesen[3]; //Kann Lebewesen, Mensch, Hund halten
		lebewesen[0] = new Lebewesen();
		lebewesen[1] = new Mensch();
		lebewesen[2] = new Hund();

		foreach (Lebewesen item in lebewesen) //Zur Compilezeit könnte hier alles drin sein
		{
			//Typvergleich um herauszufinden was item eigentlich ist
			if (item.GetType() == typeof(Mensch))
			{
				//Hier kommen wir nur herein wenn das item ein Mensch
				Mensch mensch = (Mensch) item;
				mensch.MenschMethode();
			}

			if (item is Hund) //Wenn keine weitere Unterklasse existiert, kann der is Vergleich benutzt werden
			{
				Hund h = (Hund) item;
				h.HundMethode();
			}

			item.Bewegen(10); //Jede Unterklasse muss diese Methode haben, daher kann ich sie hier aufrufen
		}

		TestLebewesen(m);
		TestLebewesen(l);
		TestLebewesen(l2);

		TestObject(123);
		TestObject("ABC");
		TestObject(false);

		//Überall wo ein Typ steht gilt Polymorphismus
		
		//abstract
		//Abstract Klassen sollen nur eine Struktur vorgeben
		//Diese Struktur besteht aus Methoden ohne Body
		//Abstrakte Klassen können nicht instanziert werden
    }

	public static void TestLebewesen(Lebewesen l) { }

	public static void TestObject(object o) { }

	public static object TestReturnObject()
	{
		return 123;
		return "ABC";
		return new Mensch();
		return false;
	}

	public static void TestParamsObject(params object[] x) { } //Über params object[] können beliebige Daten an diese Methode weitergegeben werden
}

public abstract class Lebewesen
{
	public override string ToString()
	{
		return $"{GetType().Name}";
	}

	public abstract int Alter { get; set; }

	/// <summary>
	/// Diese Methode hat keine Basisimplementation, weil sie abstract ist
	/// Jede Unterklasse muss die Methode implementieren
	/// </summary>
	public abstract void Bewegen(int distanz);
}

public class Mensch : Lebewesen
{
	public override int Alter { get; set; }

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Der Mensch bewegt sich um {distanz}m");
	}

	public void MenschMethode() { }
}

public class Hund : Lebewesen
{
	public override int Alter { get; set; }

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Der Hund bewegt sich um {distanz}m");
	}

	public void HundMethode() { }
}