using System.Reflection;

Console.WriteLine("Enter no. 1:- ");
String str1 = Console.ReadLine();
Console.WriteLine("Enter no. 2:- ");
String str2 = Console.ReadLine();

double num1 = Convert.ToDouble(str1);
double num2 = Convert.ToDouble(str2);

double sum = num1 + num2;
double diff = num1 - num2;
double mult = num1 * num2;
double division = num1 / num2;
double mod = num1 % num2;

Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Difference: {diff}");
Console.WriteLine($"Product: {mult}");
Console.WriteLine($"Division: {division}");
Console.WriteLine($"Modulus: {mod}");

