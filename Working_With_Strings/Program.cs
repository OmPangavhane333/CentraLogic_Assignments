// Code to Working with Strings

Console.WriteLine("\n__________________________________________");
Console.WriteLine("__________________________________________\n");
Console.WriteLine("******** Working With Strings *******\n");

String str1 = "Om Pangavhane";
Console.WriteLine("\nString is:- " + str1);
// String Concatenation
String a = "Hii ";
String b = "Nana";
Console.WriteLine("The Concatenated string is as follows \n" + a + b);

/*
 * There is one more concept in C# is String Interpolation.
 * C# Provides it to embed expressions within strings using the "$" Character.
 */
Console.WriteLine("\n*********  String InterPolation In C#  **********");
String name = "Om Pangavhane";
int age = 21;
String msg = $"My Name is {name} & I am {age} years Old.";

Console.WriteLine("The above example shows the String Interpolation C#");

Console.WriteLine("\n__________________________________________");
Console.WriteLine("__________________________________________\n");
