// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter no. 1:- ");
String str1 = Console.ReadLine();
Console.WriteLine("Enter no. 2:- ");
String str2 = Console.ReadLine();

double num1 = Convert.ToDouble(str1);
double num2 = Convert.ToDouble(str2);

double result = (num1 + num2) * (num1 + num2);
Console.WriteLine("Sum of square of 2 nubetrs is:- " + result);

