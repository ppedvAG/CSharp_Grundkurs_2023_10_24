for (int i = 1; i < 3000; i++)
{
    Console.WriteLine($"{i} ----- Intern: {DateTime.IsLeapYear(i)}, Eigene If: {(i % 4 == 0 && i % 100 != 0) || i % 400 == 0}");
}