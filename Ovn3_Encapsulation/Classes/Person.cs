using System.Runtime.InteropServices;

namespace Ovn3_Encapsulation.Classes;

public class Person(string firstName, string lastName, int age)
{
    private const int minAge = 18;

    public string FirstName { get; set; } = firstName;
    public string Lastname { get; set; } = lastName;

    private int _age = age >= minAge ? age : throw new ArgumentException("Age must be 18 or older.");
    public int Age
    {
        get => _age;
        set
        {
            if (value < minAge)
            {
                throw new ArgumentException("Age must be 18 or older.");
            }
            _age = value;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.Lastname} is {this.Age} years old.";
    }
}
