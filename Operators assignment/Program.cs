using System;   // Pulling in the essential .NET toolbox for console apps

// 🧑‍💼 Employee class: represents a simple worker with an identity and a name
public class Employee
{
    // 🔑 Unique identifier for each employee
    public int Id { get; set; }

    // 📝 Employee's first name
    public string FirstName { get; set; }

    // 📝 Employee's last name
    public string LastName { get; set; }

    // 🎯 Overloading the == operator so two employees are considered equal
    //     if their Id values match — identity over everything else
    public static bool operator ==(Employee left, Employee right)
    {
        // 🧪 Handling nulls like a responsible adult
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            return true;

        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;

        // 🆔 The actual equality check — Id is the deciding factor
        return left.Id == right.Id;
    }

    // 🔄 Overloading the != operator because C# insists on pairing comparison operators
    public static bool operator !=(Employee left, Employee right)
    {
        // 🚫 Simply the opposite of our == operator
        return !(left == right);
    }

    // 🧹 Overriding Equals to keep .NET consistent with our operator overloads
    public override bool Equals(object obj)
    {
        var other = obj as Employee;
        if (other == null)
            return false;

        return this.Id == other.Id;
    }

    // 🧮 Overriding GetHashCode so equal objects produce equal hash codes
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 🏗️ Creating the first employee object and giving it some identity
        Employee emp1 = new Employee
        {
            Id = 101,
            FirstName = "Kawthar",
            LastName = "AlHallak"
        };

        // 🏗️ Creating the second employee — same Id to test equality logic
        Employee emp2 = new Employee
        {
            Id = 101,
            FirstName = "Alicia",
            LastName = "Johns"
        };

        // 🧪 Testing equality using our custom overloaded operator
        bool areEqual = emp1 == emp2;

        // 📣 Announcing the result to the console with style
        Console.WriteLine($"Are the two employees equal? {areEqual}");

        // 🧪 Testing inequality just to show both operators work
        bool areNotEqual = emp1 != emp2;

        // 📣 Displaying the opposite comparison
        Console.WriteLine($"Are the two employees NOT equal? {areNotEqual}");

        // ⏳ Keeping the console open so you can admire your work
        Console.ReadLine();
    }
}
