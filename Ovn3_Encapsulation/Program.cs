using Ovn3_Encapsulation.Classes;

namespace Ovn3_Encapsulation;

class Program
{
    static void Main(string[] args)
    {
        var lines = 5;
        var persons = new List<Person>();

        TextHeader("Minimal Staff Register");

        Console.WriteLine("Please enter persons as: 'firstname' 'lastname' 'age'");
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
                if (entries.Length < 3)
                {
                    Console.WriteLine("Not enough data supplied. Try again.");
                    continue;
                }
                if (!int.TryParse(entries[2], out int age) || age < 0)
                {
                    Console.WriteLine("Invalid age supplied. Try again");
                    continue;
                }
                var person = new Person(entries[0], entries[1], age);

                persons.Add(person);
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
