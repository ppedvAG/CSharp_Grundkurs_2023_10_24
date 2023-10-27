using System.Collections.Generic;
using System.Diagnostics;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Xml.Serialization;

namespace M014;

internal class Program
{
	static void Main(string[] args)
	{
		//Klassen:
		//Directory, File, Path
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zu einem Ordner erstellen
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		SystemJson();
		return;

		//Stream auf die Datei wird geöffnet
		//-> Die Datei wird blockiert bis der Stream geschlossen wird
		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		sw.Close();

		//using Block/Statement: Schließt den unterliegenden Stream am Ende des Blocks automatisch
		//Sollte generell bei allen Streams verwendet werden
		//Kann auf allen Klassen angewandt werden, die das IDisposable Interface haben
		//z.B. SW, SR, FileStream, MemoryStream, HttpClient, DbConnection, ...
		using (StreamReader sr = new StreamReader(filePath))
		{
			//sr.ReadLine();
			//sr.ReadLine();
			//sr.ReadLine();
			string line = string.Empty;
			while (!sr.EndOfStream)
			{
				line = sr.ReadLine();
				Console.WriteLine(line);
			}
		} //.Dispose()

		//using Statement: Schließt den Stream am Ende der Methode
		using StreamReader sr2 = new(filePath);
		string line2 = string.Empty;
		while (!sr2.EndOfStream)
		{
			line2 = sr2.ReadLine();
			Console.WriteLine(line2);
		}
	} //.Dispose()

	public static void SystemJson()
	{
		//NuGet-Paket: Externe Pakete installieren
		//Tools -> NuGet Package Manager -> Manage NuGet Packages

		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zu einem Ordner erstellen
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		string json = JsonSerializer.Serialize(fahrzeuge);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		List<Fahrzeug> fahrzeuge2 = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson);
	}

	public static void NewtonsoftJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zu einem Ordner erstellen
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//string json = JsonConvert.SerializeObject(fahrzeuge);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> fahrzeuge2 = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson);
	}

	public static void XML()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zu einem Ordner erstellen
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter sw = new StreamWriter(filePath))
		{
			xml.Serialize(sw, fahrzeuge);
		}

		using (StreamReader sr = new StreamReader(filePath))
		{
			List<Fahrzeug> readFzg = (List<Fahrzeug>) xml.Deserialize(sr);
		}
	}
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}

    public Fahrzeug()
    {
        
    }
}

public enum FahrzeugMarke { Audi, BMW, VW }