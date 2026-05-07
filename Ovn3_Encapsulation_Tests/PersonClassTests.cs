using Ovn3_Encapsulation.Classes;

namespace Ovn3_Encapsulation_Tests;

public class PersonClassTests
{
    [Fact]
    public void Test_Construction()
    {
        var person = new Person("Mike", "Hansson", 30);

        Assert.Equal("Mike", person.FirstName);
        Assert.Equal("Hansson", person.Lastname);
        Assert.Equal(30, person.Age);
    }

    [Fact]
    public void Test_ToString_Override()
    {
        var person = new Person("Mike", "Hansson", 30);

        Assert.Equal(
            "Mike Hansson is 30 years old.",
            $"{person}"
        );
    }

    [Fact]
    public void Age_BelowEighteen_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Person("Mike", "Hansson", 3));
    }

    [Fact]
    public void Age_SetBelowEighteen_ThrowsArgumentException()
    {
        var person = new Person("Mike", "Hansson", 30);
        Assert.Throws<ArgumentException>(() => person.Age = 3);
    }
}
