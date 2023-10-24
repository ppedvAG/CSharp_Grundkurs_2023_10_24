#region Schleifen
using System.Net;

int a = 0;
int b = 10;
while (a < b) //Läuft solange die Bedingung true ist
{
    Console.WriteLine($"while: {a}");
    a++;
}

a = 0;

do //do-while: Wie while aber wird immer mindestens einmal ausgeführt
{
	Console.WriteLine($"do-while: {a}");
	a++;
}
while (a < b);

//while (true) { } //Endlosschleife

//break und continue

//Schleife steuern
//break: Beendet die Schleife
//continue: Spring zum Schleifenkopf zurück

while (true)
{
	if (a >= b)
		break; //Beende hier die Schleife
}

int c = 0;
int d = 10;
while (c < d)
{
	c++;
	if (c == 5)
		continue; //Springe zum Schleifenkopf zurück, überspringe den Code danach
    Console.WriteLine(c);
}

while (true)
{
    Console.WriteLine();

    if (c == 10)
		break; //do-while mit while (true) und break
}

//for + Tab + Tab
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"for: {i}");
}

//forr + Tab + Tab
for (int i = 10 - 1; i >= 0; i--)
{
    Console.WriteLine($"forr: {i}");
}

for (int i = 0, j = 1; i < 32; i++, j *= 2)
{
    Console.WriteLine($"2^{i} = {j}");
}

//Arrays durchgehen
int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
for (int i = 0; i < zahlen.Length; i++) //Kann daneben greifen
	Console.WriteLine(zahlen[i]);

foreach (int i in zahlen) //Kann nicht daneben greifen
{
    Console.WriteLine(i);
}
#endregion

#region Enums
//Enum: Eigener Datentyp mit fixen Zuständen
Console.WriteLine(DayOfWeek.Monday);

DayOfWeek heute = DayOfWeek.Tuesday;
if (heute == DayOfWeek.Friday)
{
    Console.WriteLine("Bald Wochenende");
}

string heuteStr = "Tuesday";
if (heuteStr == "tuesday")
{
	//Fehleranfällig
	//Bei Enum sind nur die gegebenen Zustände möglich
	//Bei String sind effektiv unendlich viele Zustände möglich
}

//int zu Enum
int zahl = 2;
Wochentag tag = (Wochentag) zahl;
zahl = (int) tag;

//String zu Enum
string str = "Mo";
Wochentag parseTag = Enum.Parse<Wochentag>(str); //In den Spitzen Klammern den Typen des Ergebnisses angeben

Wochentag[] alleTage = Enum.GetValues<Wochentag>(); //Enum mit allen Tagen generieren
foreach (Wochentag wt in alleTage)
    Console.WriteLine(wt);
#endregion

#region Switch
//Switch: Ermöglicht schöne Vergleiche von einem Wert
Wochentag w = Wochentag.Di;
if (w == Wochentag.Mo || w == Wochentag.Di || w == Wochentag.Mi || w == Wochentag.Do || w == Wochentag.Fr)
    Console.WriteLine("Wochentag");
else if(w == Wochentag.Sa || w == Wochentag.So)
    Console.WriteLine("Wochenende");
else
    Console.WriteLine("Fehler");

//-->

switch (w) //Selbiges wie die obere if-else Konstruktion
{
	case Wochentag.Mo: //w == Mo
	case Wochentag.Di:
	case Wochentag.Mi:
	case Wochentag.Do:
	case Wochentag.Fr:
        Console.WriteLine("Wochentag");
		break; //break muss am Ende von jeder Case Gruppe stehen
	case Wochentag.Sa:
	case Wochentag.So:
        Console.WriteLine("Wochenende");
		break;
	default: //else
        Console.WriteLine("Fehler");
		break;
}

switch (w) //switch -> Strg + . -> Add missing cases/Add both
{
	case Wochentag.Mo:
	case Wochentag.Di:
	case Wochentag.Mi:
	case Wochentag.Do:
	case Wochentag.Fr:
		Console.WriteLine("Wochentag");
		break;
	case Wochentag.Sa:
	case Wochentag.So:
		Console.WriteLine("Wochenende");
		break;
	default:
		Console.WriteLine("Fehler");
		break;
}

//Boolscher Switch
switch (w)
{
	case >= Wochentag.Mo and <= Wochentag.Fr:
		Console.WriteLine("Wochentag");
		break;
	case Wochentag.Sa or Wochentag.So:
		Console.WriteLine("Wochenende");
		break;
	default:
		Console.WriteLine("Fehler");
		break;
}
#endregion

//Enum muss ganz unten definiert werden
//Jeder Enumwert hat eine Zahl dahinter (startend bei 0)
enum Wochentag
{
	Mo = 1, Di, Mi, //Hier 1, 2, 3
	Do = 10, Fr, Sa, So //Hier 10, 11, 12, 13
}