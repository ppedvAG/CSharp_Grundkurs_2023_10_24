#region Arrays
//Array: Eine Variable die mehrere Werte halten kann
using System.Runtime.CompilerServices;

int[] zahlen; //An den Typen die [] anhängen um eine Array-Variable anzulegen
zahlen = new int[10]; //Erstellt ein Array mit Länge 10 (10 Plätze, Index fängt bei 0 an -> 0-9)
zahlen[3] = 5;
Console.WriteLine(zahlen[3]);

//Direkte Initialisierung
int[] direkt1 = new int[] { 1, 2, 3, 4, 5 }; //Länge 5, Index 0-4
int[] direkt2 = new[] { 1, 2, 3, 4, 5 };
int[] direkt3 = { 1, 2, 3, 4, 5 };

Console.WriteLine(zahlen.Length); //Gibt die Anzahl der Felder zurück

Console.WriteLine(zahlen.Contains(5)); //Gibt zurück, ob das Array den gegebenen Wert enthält

//Mehrdimensionale Arrays
int[,] array2D = new int[3, 3]; //Matrix (3x3)
array2D[1, 1] = 5;
Console.WriteLine(array2D[1, 1]);

array2D = new int[,]
{
	{ 1, 2, 3 },
	{ 4, 5, 6 },
	{ 7, 8, 9 }
};

Console.WriteLine(array2D.Rank); //Anzahl der Dimensionen (hier 2)
Console.WriteLine(array2D.GetLength(0)); //3
Console.WriteLine(array2D.GetLength(1)); //3
#endregion

#region Bedingungen
int zahl1 = 7;
int zahl2 = 4;

if (zahl1 < zahl2)
{

}
else
{

}

if (zahlen.Contains(zahl1))
{
	//zahlen enthält zahl1
}

//XOR: True wenn die Bedingungen unterschiedlich sind
if (zahlen.Contains(zahl1) ^ zahlen.Contains(zahl2))
{
	//zahl1 enthalten oder zahl2 enthalten aber nicht beide
}

if (zahlen.Contains(zahl1) || zahlen.Contains(zahl2))
{
	//zahl1 enthalten oder zahl2 enthalten oder beide
}

if (!zahlen.Contains(zahl1)) //! vor Boolean ist eine Invertierung
{
	//zahlen enthält nicht zahl1
}

//Ternary Operator
//Fragezeichen Operator (?): Ermöglicht, if/else in eine Zeile zu schreiben
if (zahlen.Contains(zahl1))
{
    Console.WriteLine("Zahlen enthält zahl1");
}
else
{
	Console.WriteLine("Zahlen enthält nicht zahl1");
}

//Vereinfachung 1: Klammern weglassen bei einzeiligen Ifs
if (zahlen.Contains(zahl1))
	Console.WriteLine("Zahlen enthält zahl1");
else
	Console.WriteLine("Zahlen enthält nicht zahl1");

//Vereinfachung 2: Ternary Operator
string output = zahlen.Contains(zahl1) ? "Zahlen enthält zahl1" : "Zahlen enthält nicht zahl1";
Console.WriteLine(output);

//? ist if, : ist else
//Der Ternary Operator muss immer ein Ergebnis haben
//zahlen.Contains(zahl1) ? Console.WriteLine("Zahlen enthält zahl1") : Console.WriteLine("Zahlen enthält nicht zahl1"); //Nicht möglich, da cw void zurück gibt
int summe = zahl1 > zahl2 ? zahl1 + zahl2 : zahl1 - zahl2;
Console.WriteLine(summe);
#endregion