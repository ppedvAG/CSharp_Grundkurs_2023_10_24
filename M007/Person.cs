namespace M007;

/// <summary>
/// Rechtsklick auf Projekt -> Add -> Class -> Namen geben
/// </summary>
public class Person
{
	#region Variable
	//Eine Variable ist ein normales Feld, welches beschrieben werden kann
	//Nachteil: Benutzer kann hier alles schreiben
	//string vorname = "123"; ist erlaubt
	//Über Get- und Setmethoden kann der Zugriff auf ein Feld eingeschränkt werden

	/// <summary>
	/// private: Kann nur innerhalb der Klasse angegriffen werden
	/// public: Kann überall angegriffen werden
	/// </summary>
	private string vorname;

	public string GetVorname()
	{
		return vorname;
	}

	/// <summary>
	/// Hier kann jetzt das Feld nurnoch indirekt angegriffen werden -> Überprüfungen, Set Methode könnte auch weggelassen werden
	/// </summary>
	/// <param name="neuerVorname"></param>
	public void SetVorname(string neuerVorname)
	{
		if (neuerVorname.Length >= 3 && neuerVorname.Length <= 15 && neuerVorname.All(char.IsLetter)) //Überprüfungen
			vorname = neuerVorname;
		else
            Console.WriteLine("Neuer Vorname ungültig"); //Fehlerbehandlung ausbaufähig
    }
	#endregion

	#region Property
	//Ein Property stellt eine Syntaktische Vereinfachung von Get- und Setmethode dar
	//Ein Property hat einen Get-Accessor und einen Set-Accessor
	//Die Accessoren können geöffnet werden, um eigenen Code zu implementieren
	//Verschiedene Properties:
	//- Full Property
	//- Auto Property
	//- Get-Only Property

	//Full Property
	//Stellt den vorherigen Code von Variable dar, nur syntaktisch anders
	//Besteht aus private Feld und Property mit Get und Set
	private string nachname;

	public string Nachname
	{
		get => nachname;
		set
		{
			//neuerVorname -> value
			if (value.Length >= 3 && value.Length <= 15 && value.All(char.IsLetter)) //Überprüfungen
				nachname = value;
			else
				Console.WriteLine("Neuer Nachname ungültig");
		}
	}

    //Kann schnell erzeugt werden mit dem propfull Snippet

    //Auto Property
	//Verhält sich wie eine normale Variable
	//Kann im Gegensatz zu einer Variable auch Access Modifier bei get und set definieren
    public int Alter { get; set; }

	public int Gehalt { get; private set; } //User darf von außen kein Gehalt hier hinein schreiben

	//Get-Only Property
	//Auto Property aber ohne Setter
	public string VollerName
	{
		get => vorname + " " + nachname;
	}

	public string VollerName2 => vorname + " " + nachname; //Kurzschreibweise

    //Unterschied zwischen = und =>
    //=: Berechnet den Wert und schreibt ihn fix in die Variable herein
    //=>: Berechnet den Wert jedes mal neu wenn er angegriffen wird
    #endregion

    #region Konstruktor
    //Ein Konstruktor nimmt vom Benutzer konkrete Werte
    //Hier in der Klasse gibt es keine konkreten Werte

	/// <summary>
	/// Dieser Code wird ausgeführt, wenn eine Person ohne Parameter erstellt wird (new Person())
	/// </summary>
    public Person()
    {
        Console.WriteLine($"Person erstellt {GetHashCode()}");
		ZaehlePerson();
    }

	/// <summary>
	/// Dieser Code wird ausgeführt, wenn eine Person mit vorname und nachname erstellt wird (mit new, new Person("Name1", "Name2"))
	/// </summary>
	/// <param name="vorname"></param>
	/// <param name="nachname"></param>
    public Person(string vorname, string nachname) : this()
	{
		this.vorname = vorname; //this: Greife nach oben, vorname hier und vorname oben heißen gleich -> Durch this differenzieren
		this.nachname = nachname;
	}

	/// <summary>
	/// Konstruktoren verketten mittels this(...)
	/// Ermöglicht, die Ausführung mehrerer Konstruktoren bei Verwendung eines Konstruktors
	/// Vorteil: Wenn sich in einem Konstruktor der Kette etwas ändert, wird diese Änderung bei allen Konstruktoren übernommen
	/// Durch mehrere this können lange Ketten erstellt werden
	/// </summary>
	public Person(string vorname, string nachname, int alter) : this(vorname, nachname)
	{
		Alter = alter;
	}

	public Person(string vorname, string nachname, int alter, int gehalt) : this(vorname, nachname, alter)
	{
		Gehalt = gehalt;
	}
	#endregion

	/// <summary>
	/// Destruktor: Code der beim Einsammeln des GC aufgerufen wird
	/// GetHashCode(): Gibt die Speicheradresse des Objekts zurück
	/// </summary>
	~Person()
	{
        Console.WriteLine($"Die Person wurde eingesammelt {GetHashCode()}");
    }

	public static int AnzahlPersonen { get; private set; } //Globaler Zähler

	public static void ZaehlePerson() //Globale Funktion
	{
		AnzahlPersonen++;
	}
}
