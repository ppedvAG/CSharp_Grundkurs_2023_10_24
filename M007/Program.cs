using System.Runtime.CompilerServices;

namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		#region GC
		for (int i = 0; i < 5; i++)
		{
			Person p = new Person();
		}

		GC.Collect();
		GC.WaitForPendingFinalizers();
		#endregion

		#region Static
		//Static: Global, benötigen keine Objekte um aufgerufen zu werden
		//Statische Funktionen liegen innerhalb einer Klasse, haben aber mit der Klasse selbst nichts zu tun
		//Werden über Klassenname.Funktionsname aufgerufen

		Console.WriteLine(); //Muss ohne Objekt verwendet werden
		//Console c = new Console();
		//c.WriteLine(); //Nicht möglich

		//Bei nicht-statischen Funktionen benötige ich immer ein Objekt der entsprechenden Klasse
		Person p2 = new Person("Max", "");
		Person p3 = new Person("Tim", "");
		Person p4 = new Person("Tom", "");
		p2.SetVorname("");
        //Person.SetVorname(""); //Benötigt ein Objekt
		Person.ZaehlePerson(); //Statische Funktion in Person benötigt kein Objekt
        Console.WriteLine(Person.AnzahlPersonen);

        Console.WriteLine(DateTime.Now); //Macht keinen Sinn hier ein Objekt zu erstellen, weil die Jetzt-Zeit ist einfach da
		#endregion

		#region Werte- und Referenztypen
		//Wertetypen
		//struct
		//z.B. int, double, bool, ...
		//Bei Vergleich werden die Inhalte verglichen
		//Bei einer Zuweisung wird der Inhalt kopiert
		int original = 5;
		int x = original; //5 wird kopiert
		original = 10;

		//Referenztypen
		//class
		//z.B. Person, Fahrzeug, Array, ...
		//Bei Vergleich werden die Speicheradressen (GetHashCode) verglichen
		//Bei einer Zuweisung wird eine Referenz auf das Objekt angelegt
		Person person = new Person("Max", "Mustermann");
		Person referenz = person;
		person.Alter = 20; //person und referenz enthalten beide einen Zeiger auf das gleiche Objekt -> Alter wird bei beiden Variablen geändert

		int mult = 5;
		Mal2(ref mult); //Referenz zu der Variable hier übergeben (statt Kopie)
        Console.WriteLine(mult);
		#endregion

		#region Datumswerte
		DateTime datum = new DateTime(1986, 04, 24);
        Console.WriteLine(datum.DayOfYear);
        Console.WriteLine(datum.DayOfWeek);

		datum += new TimeSpan(48, 0, 0);
		datum += TimeSpan.FromDays(3);
		datum -= TimeSpan.FromDays(3);

		TimeSpan diff = DateTime.Now - new DateTime(1998, 07, 18);
		Console.WriteLine(diff.Days);
		#endregion

		#region Null
		//Null: Kein Wert
		//Funktioniert nur bei Klassen

		//int n = null; //nicht möglich bei Wertetypen
		Person person1 = new Person(); //Referenz zu dem unterliegenden Objekt
		Person zwischenspeicher = person1; //Zweite Referenz zu dem unterliegenden Objekt
		person1 = null; //Zeiger von person1 auf das Objekt wird gelöscht (statt dem Objekt selbst)

		//person1.GetVorname(); //Absturz, da person1 nicht existiert

		if (person1 != null)
		{

		}

		if (person1 is not null)
		{

		}

        Console.WriteLine(person1?.GetVorname()); //Null Propagation: Schneller Null-Check, Code nach dem ?. wird nur ausgeführt wenn das Objekt nicht null ist
		string vorname = "test";
		vorname = person1?.GetVorname();

        Console.WriteLine(person1?.Alter);
		int? alter = person1?.Alter; //? nach Typ: Nullable Typ
		//Hier nullable int
		alter = null;

		int alter2 = person1?.Alter == null ? -1 : person1.Alter; //int? entfernen
		#endregion
	}

	static void Mal2(ref int x) //ref: Referenzierbaren Parameter erstellen (int referenzierbar machen)
	{
		x *= 2;
        Console.WriteLine(x);
    }
}