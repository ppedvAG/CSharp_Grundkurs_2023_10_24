internal class Program
{
	/// <summary>
	/// Einstiegspunkt des Programms, muss in jedem Programm genau einmal existieren
	/// </summary>
	public static void Main(string[] args)
	{
		//Funktionen
		//Behälter für Code mit einem Namen und (optional) Parametern
		//Über den Namen kann der Code in der Funktion aufgerufen werden

		//Aufbau
		//<Modifier> <Rückgabetyp> <Name>(<Par1>, <Par2>, ...)
		//{ <Code> }

		//Rückgabetyp
		//Bestimmt den Typen des Ergebnisses
		//Wird in der Funktion mit dem return Keyword zurück gegeben

		double d = Math.Round(5.5); //Ergebnis der Funktion in eine Variable schreiben
		Console.WriteLine(); //void Funktion hat kein Ergebnis

		//Name
		//Sollte nur aus Buchstaben, Nummern und Underscores bestehen
		//Sollten auch keine Umlaute haben

		//Parameterliste
		//Einer Funktion können Daten mitgegeben werden, in Form von Parametern
		//Die Parameter müssen beim Aufruf der Funktion mitgegeben werden

		double summe = Addiere(4, 5); //Funktionsaufruf über Name, Ergebnis in eine Variable schreiben
		PrintAddiere(3, 5);
		Console.WriteLine(summe);

		double d2 = Addiere(3, 4); //int Funktion
		double d3 = Addieren(3.0, 4); //double Funktion über einen Double Parameter

		Summiere(3, 5);
		Summiere(4, 5, 6);
		Summiere(4, 5, 6, 7, 8, 9);
		Summiere(3);
		Summiere(); //Keine Parameter sind auch beliebig viele Parameter

		Addiere(5, 8); //z = 0
		Addiere(5, 8, 5); //z = 5

		PrintPerson(nachname: "", adresse: ""); //Methode konfigurierbar machen, immer nur die Parameter angeben die auch wirklich benötigt werden
		PrintPerson(vorname: "", alter: 0);
		PrintPerson(nachname: "", alter: 0);

		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9, false); //Sonderfall
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);

		string zahl = "123";
		//int.Parse(zahl); //Programm stürzt ab wenn zahl nicht numerisch ist

		int ergebnis;
		bool funktioniert = int.TryParse(zahl, out ergebnis); //Wenn die TryParse Funktion ausgeführt wird, steht das Ergebnis am Ende der Funktion in der mit out angegebenen Variable
		if (funktioniert)
		{
            Console.WriteLine($"Parsen hat funktioniert: {ergebnis}");
        }
		else
		{
            Console.WriteLine("Parsen hat nicht funktioniert");
        }


		int differenz;
		int sum = AddiereUndSubtrahiere(4, 8, out differenz); //Mehrere Werte zurückgeben
        Console.WriteLine($"Summe: {sum}, Differenz: {differenz}");
    }

	//Funktion mit einem Rückgabetyp benötigen ein return
	static double Addieren(double x, double y)
	{
		return x + y;
	}

	//Funktionsüberladung: Ermöglicht, das Erstellen von gleichnamigen Funktionen, wenn sich die Parameter unterscheiden
	static int Addieren(int x, int y)
	{
		return x + y;
	}
	
	//void Funktionen benötigen kein return
	static void PrintAddiere(double x, double y)
	{
		Console.WriteLine($"{x} + {y} = {x + y}");
	}

	//params: Ermöglicht, beliebig viele Parameter zu übergeben beim Funktionsaufruf
	static int Summiere(params int[] zahlen)
	{
		return zahlen.Sum();
	}

	static int Addiere(int x, int y, int z = 0)
	{
		return x + y + z;
	}

	//Beim Aufruf dieser Funktion müssen nur die Parameter angegeben werden, die von Interesse sind
	static void PrintPerson(string vorname = "", string nachname = "", int alter = 0, string adresse = "") //Hier mehr als 4 Parameter vorstellen
	{
		//...
	}

	static int AddiereOderSubtrahiere(int x, int y, bool add = true)
	{
		if (add)
			return x + y;
		else
			return x - y;
	}

	static int AddiereUndSubtrahiere(int x, int y, out int diff)
	{
		diff = x - y;
		return x + y;
	}

	static void PrintDivision(int x, int y)
	{
		if (y == 0)
			return; //Beendet die Funktion, kann in void Funktionen ohne Rückgabewert verwendet werden
        Console.WriteLine($"{x} / {y} = {x / y}");
    }
}