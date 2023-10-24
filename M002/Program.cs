#region Variablen
//Variablen
//Aufbau:
//<Typ> <Name>;
//<Typ> <Name> = <Wert>;
int zahl;
int zahl2 = 5;
Console.WriteLine(zahl2);

/*
 Mehrzeilige
 Kommentare
*/

//int: Ganze Zahl zwischen -2^31 und 2^31-1
//double: Kommazahl zwischen 6.2*-10^308 und 6.2*10^308
//string: Text
//bool: Wahr-/Falsch Wert (true oder false)

double d = 93_284_923.23_759_132_758; //_: Trennzeichen, nur im Code sichtbar
Console.WriteLine(d); //cw + Tab: Console.WriteLine

float f = 32597.23579f; //mit f am Ende die Kommazahl zu Float konvertieren

decimal m = 2958325.325973209m; //mit m am Ende die Kommazahl zu Decimal konvertieren

string s = "Hallo"; //String erzeugen mit Doppelten Hochkomma (keine einzelnen Hochkomma)
Console.WriteLine(s);

char c = 'A'; //Char erzeugen mit Einzelnen Hochkomma

bool wahr = true;
bool falsch = false;
#endregion

#region Strings
//Stringverknüpfung
string plus = "Die Zahl ist " + zahl2;
Console.WriteLine(plus);

string kombi = "Die Zahl ist " + zahl2 + " der Text ist " + s + " die Kommazahl ist " + d;
Console.WriteLine(kombi);

//String Interpolation ($-String): Ermöglicht, das Einbauen von Code in einen String
string interpolation = $"Die Zahl ist {zahl2} der Text ist {s} die Kommazahl ist {d}"; //Mit { und } Code in den String einbauen
Console.WriteLine(interpolation);

//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
Console.WriteLine("Umbruch \n Umbruch");
Console.WriteLine("Tab \t Tab");

//Verbatim String (@-String): Ignoriert Escape-Sequenzen
Console.WriteLine(@"Umbruch
Umbruch");
string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2023_10_24";
#endregion

#region Eingabe
//Eingabe
//string eingabe = Console.ReadLine();
//Console.WriteLine($"Deine Eingabe ist {eingabe}");

//ConsoleKeyInfo info = Console.ReadKey(true); //Benötigt kein Enter um fortzufahren, true um den Key des Users nicht in der Konsole anzuzeigen
//Console.WriteLine($"Du hast {info.Key} gedrückt");
#endregion

#region Konvertierungen
//String zu anderem Typen
//Console.WriteLine("Gib eine Zahl ein: ");
////int zahlEingabe = Console.ReadLine(); //Nicht möglich
//string zahlEingabe = Console.ReadLine();
//int parseEingabe = int.Parse(zahlEingabe);

//Anderer Typ zu String
//Console.WriteLine(parseEingabe.ToString());

//Anderer Typ zu anderer Typ
//Über Typecast (Typ in Klammer vor der Variable)
double d2 = 3598729.3259872;
//int x = d2; //int und double passt nicht, da double eine Kommazahl ist
int x = (int) d2; //Explizit die Umwandlung erzwingen
double d3 = x; //Implizite Konvertierung, da int immer in Double passt
#endregion

#region Arithmetik
int z1 = 4;
int z2 = 7;

//Zwei Möglichkeiten für Berechnungen
//z1 + z2; //Nur die Berechnung
z1 += z2; //Befehl (Addiere z2 auf z1)

int summe = z1 + z2;
Console.WriteLine(z1 + z2);

Console.WriteLine(z1 % z2); //Modulo: Rest der Division

//Verwendung des Modulo Operators
Console.WriteLine(z1 % 2); //Test ob eine Zahl gerade ist (0: gerade, 1: ungerade)
Console.WriteLine(z1 % 10); //Die letzten X Ziffern einer Zahl herausfinden

z1++; //Erhöhe die Zahl um 1
z1--; //Verringere die Zahl um 1

//Divisionen
Console.WriteLine("---------");
Console.WriteLine(6 / 4); //1, weil Typen -> 2 Ints dadurch eine Int-Division
Console.WriteLine((double) 6 / 4); //Durch Konvertierung eine Kommadivision erzwingen
Console.WriteLine(6 / 4d); //Durch schnelle Konvertierung auch möglich
Console.WriteLine(6 / 4.0);
Console.WriteLine((double) z1 / z2);

Math.Floor(1.2); //Abrunden
Math.Ceiling(1.2); //Aufrunden
Math.Round(4.3); //4
Math.Round(4.7); //5
Math.Round(4.5); //4, rundet zur nächsten geraden Zahl
Math.Round(5.5); //6, rundet zur nächsten geraden Zahl
#endregion