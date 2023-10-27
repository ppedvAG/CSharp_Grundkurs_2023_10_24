namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		try
		{
			string eingabe = Console.ReadLine();
			int x = int.Parse(eingabe);
			if (x == 0)
				throw new TestException("Die Zahl darf nicht 0 sein");
		}
		catch (FormatException e)
		{
			//Wenn hier rein, dann werden die Blöcke im Anschluss nicht ausgeführt
            Console.WriteLine(e);
		}
		catch (OverflowException e)
		{
			Console.WriteLine(e);
		}
		catch (Exception e)
		{
            Console.WriteLine(e);
        }
		finally
		{
            Console.WriteLine("Fertig");
        }
	}
}

public class TestException : Exception
{
	public TestException(string? message) : base(message)
	{
	}
}