namespace M006;

public class Kurs
{
	public string Titel { get; set; }

	public int Dauer { get; set; }

	public bool Teilzeit { get; set; }

	public Person Trainer { get; set; }

	public Person[] Teilnehmer { get; set; }

	/// <summary>
	/// Cursor auf Klassenname -> Strg + . -> Generate Constructor
	/// </summary>
	public Kurs(string titel, int dauer, bool teilzeit, Person trainer, params Person[] tn)
	{
		Titel = titel;
		Dauer = dauer;
		Teilzeit = teilzeit;
		Trainer = trainer;
		Teilnehmer = tn;
	}

	public void TeilnehmerHinzufuegen(params Person[] p)
	{
		//Wir erstellen ein neues Array mit der neuen Größe
		//this.Teilnehmer.Length + p.Length

		//Person[] neueTn = new Person[Teilnehmer.Length + p.Length];
		//for (int i = 0; i < Teilnehmer.Length; i++)
		//	neueTn[i] = Teilnehmer[i];

		//for (int i = Teilnehmer.Length; i < neueTn.Length; i++)
		//	neueTn[i] = p[i - Teilnehmer.Length];

		//Teilnehmer = neueTn;

		Teilnehmer = Teilnehmer.Concat(p).ToArray();
	}
}
