namespace Ovn3_Encapsulation.Classes;

public class Person(string firstName, string lastName, int age)
{
  public string FirstName { get; set; } = firstName;
  public string Lastname { get; set; } = lastName;
  public int Age { get; set; } = age;

  public override string ToString()
  {
    return $"{this.FirstName} {this.Lastname} is {this.Age} years old.";
  }
}
