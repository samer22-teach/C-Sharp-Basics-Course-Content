using System;

class PackageExpress
{
    static void Main()
    {
        // Display welcome message
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Get package weight
        Console.Write("Please enter the package weight (in lbs): ");
        double weight = GetValidInput();
        if (weight == -1) return; // Exit if invalid input

        // Check weight limit
        if (weight > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }

        // Get package dimensions
        double width = GetDimension("width");
        if (width == -1) return; // Exit if invalid input

        double height = GetDimension("height");
        if (height == -1) return; // Exit if invalid input

        double length = GetDimension("length");
        if (length == -1) return; // Exit if invalid input

        // Check size limit
        if (width + height + length > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }

        // Calculate and display the quote
        double quote = CalculateQuote(width, height, length, weight);
        Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
        Console.WriteLine("Thank you for using Package Express!");
    }

    // Get a valid numerical input from the user
    static double GetValidInput()
    {
        if (!double.TryParse(Console.ReadLine(), out double value) || value <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            return -1;
        }
        return value;
    }

    // Get a dimension (width, height, or length) from the user
    static double GetDimension(string dimension)
    {
        Console.Write($"Please enter the package {dimension} (in inches): ");
        return GetValidInput();
    }

    // Calculate the shipping quote
    static double CalculateQuote(double width, double height, double length, double weight)
    {
        double totalVolume = width * height * length;
        return (totalVolume * weight) / 100;
    }
}
