using Ovn3_Encapsulation.Classes;

namespace Ovn3_Encapsulation_Tests;

public class PersonClassTests
{
    [Fact]
    public void Test_Construction()
    {
        var person = new Person("Mike", "Hansson", 30, 3000);

        Assert.Equal("Mike", person.FirstName);
        Assert.Equal("Hansson", person.Lastname);
        Assert.Equal(30, person.Age);
        Assert.Equal(3000, person.Salary);
    }

    [Fact]
    public void Test_ToString_Override()
    {
        var person = new Person("Mike", "Hansson", 30, 3000);

        Assert.Equal(
            "Mike Hansson recieves 3000.00 dollars.",
            $"{person}"
        );
    }

    [Fact]
    public void Age_BelowEighteen_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Person("Mike", "Hansson", 3, 3000));
    }

    [Fact]
    public void Age_SetBelowEighteen_ThrowsArgumentException()
    {
        var person = new Person("Mike", "Hansson", 30, 3000);
        Assert.Throws<ArgumentException>(() => person.Age = 3);
    }

    [Fact]
    public void Older_GetsFull_Bonus()
    {
        var person = new Person("Mike", "Hansson", 30, 3000);

        person.IncreaseSalary(10);
        Assert.Equal(3300, person.Salary);
    }

    [Fact]
    public void Younger_GetsHalf_Bonus()
    {
        var person = new Person("Maja", "Petterson", 22, 2200);

        person.IncreaseSalary(10);
        Assert.Equal(2310, person.Salary);
    }
}
