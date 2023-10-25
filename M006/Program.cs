using System.Diagnostics;

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		//Namespace
		//"Package": Gruppiert Typen (Klassen, Structs, Enums, Delegates, ...)
		//Jedes Projekt sollte einen Namespace haben (hier M006)
		//Namespaces können verschachtelt werden (z.B. M006.UI)

		//Beispiele:
		//System: Standardstrukturen (int, string, long, double, ...)
		//System.IO: Dateiklassen (File, Directory, Path, ...)
		//System.Net.Http: HttpClient, HttpStatusCode
		
		//using: Namespaces importieren (die standardmäßig nicht dabei sind)
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
        //...
        Console.WriteLine(stopwatch.ElapsedMilliseconds);


		Person p = new Person();
		p.SetVorname("Max"); //Extra Methode für das Setzen eines Felds
		p.Nachname = "Mustermann"; //Keine extra Methode -> optisch schöner

		Person p2 = new Person("Max", "Mustermann");
		Person p3 = new Person("Max", "Mustermann", 30);

		//Assozation von Objekten
		//Objekte innerhalb von anderen Objekten referenzieren (Objekte verschachteln)
		Person trainer = new Person("", "", 25, 2_000_000);
		Person t1 = new Person("", "", 29, 1_500_000);
		Person t2 = new Person("", "", 40, 2_300_000);
		Person t3 = new Person("", "", 36, 1_800_000);
		Person t4 = new Person("", "", 55, 2_800_000);
		Person t5 = new Person("", "", 25, 2_000_000);
		Kurs k = new Kurs("C# Grundkurs", 4, false, trainer, t1, t2, t3, t4, t5);
		//In k existieren Referenzen (Zeiger) auf die Personen Objekte
		k.TeilnehmerHinzufuegen(p, p2, p3);
    }
}