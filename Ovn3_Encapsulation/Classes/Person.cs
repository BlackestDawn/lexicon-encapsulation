using System.Runtime.InteropServices;

namespace Ovn3_Encapsulation.Classes;

public class Person(string firstName, string lastName, int age, decimal salary)
{
    private const int minAge = 18;
    private const int minSymbolsInName = 3;

    private string _firstName = firstName.Length >= 3 ? firstName : throw new ArgumentException($"First name cannot contain fewer than {minSymbolsInName} symbols!");
    public string FirstName
    {
        get => this._firstName;
        set
        {
            if (value.Length <= minSymbolsInName)
            {
                throw new ArgumentException($"First name cannot contain fewer than {minSymbolsInName} symbols!");
            }
            this._firstName = value;
        }
    }

    public string LastName { get; set; } = lastName;

    private int _age = age >= minAge ? age : throw new ArgumentException($"Age must be {minAge} or older.");
    public int Age
    {
        get => this._age;
        set
        {
            if (value < minAge)
            {
                throw new ArgumentException($"Age must be {minAge} or older.");
            }
            this._age = value;
        }
    }

    public decimal Salary { get; set; } = salary;

    public override string ToString()
    {
        return $"{this.FirstName} {this.Lastname} recieves {this.Salary:F2} dollars.";
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age < 30)
        {
            percentage /= 2;
        }

        this.Salary *= 1 + (percentage / 100);
    }
}
