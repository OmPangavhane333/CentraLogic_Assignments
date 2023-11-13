using System.Diagnostics.CodeAnalysis;

internal class Program
{
    private static void Main(string[] args)
    {
        // Code to print current Date and Time .Now is used.
        DateTime myDateTime= DateTime.Now; // 
        Console.WriteLine("Current Date and Time:- " + myDateTime);

        // Working with Time Only
        TimeOnly time = new TimeOnly(18,05); // It only print only Time.
        Console.WriteLine("Custom Time:- " + time);

        // Working with Date Only
        DateOnly date = new DateOnly(2023,11,12);
        Console.WriteLine("Custome Date:- " + date); // It Only Prints only Date

        /* Dates Functions
         * Adding/Manipulating Dates and Times
         * functions:- Adddays, AddHours, AddMinutes, AddMonths, AddSeconds, AddYears
         */
        DateTime futureDate = myDateTime.AddHours(24);
        Console.WriteLine("Date and Time After 24 Hours:- " + futureDate);

        DateTime pastDate = myDateTime.AddDays(-1);
        Console.WriteLine("Past Date:- " + pastDate);

        DateTime pastminutes = myDateTime.AddMinutes(-30);
        Console.WriteLine("Past 30 Minutes:-  " + pastminutes);
    }
}