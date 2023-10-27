namespace Fahrzeugpark;

internal interface IBeladbar
{
	Fahrzeug Ladung { get; set; }

	void Belade(Fahrzeug fzg);

	Fahrzeug Entlade();
}