using Ovn3_Encapsulation.Classes;

namespace Ovn3_Encapsulation;

class Program
{
    static void Main(string[] args)
    {
        var lines = 5;
        var persons = new List<Person>();

        TextHeader("Minimal Staff Register");

        Console.WriteLine("Please enter persons as: 'firstname' 'lastname' 'age' 'salary'");
        for (int i=0; i<lines; i++)
        {
            while (true) {
                Console.Write($"Person {i+1}/{lines}: ");
                string? cmdArgs = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(cmdArgs))
                {
                    Console.WriteLine("Input can't be empty. Try again.");
                    continue;
                }
                string[] entries = cmdArgs.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (entries.Length < 4)
                {
                    Console.WriteLine("Not enough data supplied. Try again.");
                    continue;
                }
                if (!int.TryParse(entries[2], out int age) || age < 0)
                {
                    Console.WriteLine("Invalid age supplied. Try again");
                    continue;
                }
                if (!decimal.TryParse(entries[3], out decimal salary))
                {
                    Console.WriteLine("Invalid salary supplied. Try again.");
                    continue;
                }
                try
                {
                    var person = new Person(entries[0], entries[1], age, salary);
                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                break;
            }
        }

        persons.OrderBy(p => p.FirstName)
            .ThenBy(p => p.Lastname)
            .ToList()
            .ForEach(p => Console.WriteLine(p));
    }

    private static void TextHeader(string text)
    {
        string borderLine = new('*', text.Length + 4);
        Console.WriteLine($"\n{borderLine}\n* {text} *\n{borderLine}");
    }
}
