namespace M012;

public static class ExtensionMethods
{
	public static int Quersumme(this int x) //Mit this diese Methode an einen beliebigen Typen anhängen
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x)
	{
		return x.OrderBy(e => Random.Shared.Next()); //Weise jedem Element der Liste eine Zufallszahl zu, und sortiere nach dieser Zufallszahl
	}
}
