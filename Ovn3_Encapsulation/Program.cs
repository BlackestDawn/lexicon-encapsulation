using Ovn3_Encapsulation.Classes;

namespace Ovn3_Encapsulation;

class Program
{
    static void Main(string[] args)
    {
        int lines = 5;
        int iter = 0;
        var persons = new List<Person>();

        TextHeader("Minimal Staff Register");

        Console.WriteLine("Please enter persons as: 'firstname' 'lastname' 'age' 'salary'");
        while (iter < lines) {
            Console.Write($"Person {iter+1}/{lines}: ");
            try
            {
                string[]? cmdArgs = Console.ReadLine().Split(" ", options: StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(cmdArgs[0], cmdArgs[1], Convert.ToInt32(cmdArgs[2]), Convert.ToDecimal(cmdArgs[3]));
                persons.Add(person);
                iter++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Not enough data supplied. Try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something else went wrong: {ex.Message}");
            }
        }

        Console.Write("Enter a percentage bonus to apply: ");
        int bonus = Convert.ToInt32(Console.ReadLine());
        if (bonus < 0)
        {
            Console.WriteLine("Bonus cannot be negative, exiting.");
        }
        persons.ForEach(p =>
        {
            p.IncreaseSalary(bonus);
            Console.WriteLine(p);
        });
    }

    private static void TextHeader(string text)
    {
        string borderLine = new('*', text.Length + 4);
        Console.WriteLine($"\n{borderLine}\n* {text} *\n{borderLine}");
    }
}
