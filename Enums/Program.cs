using System;

// Code to understand the concept of Enums

enum Days
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday, 
    Friday,
    Saturday
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("\n____________________________");
        Console.WriteLine("____________________________\n");
        Console.WriteLine("Working With Enums in C#\n");

        foreach (Days day in Enum.GetValues(typeof(Days)))
        {
            Console.WriteLine(day);
        }

    }
}