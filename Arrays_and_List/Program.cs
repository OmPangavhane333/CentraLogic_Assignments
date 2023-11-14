// In this program we are working with arrays and List.

Console.WriteLine("******** Working With Arrays ********\n");

// Firstly we are working with arrays. Above is the initialization and storing the array is shown
int[] numbers = new int[5] { 10, 20, 30, 40, 50 };

//accessing elements by index
int firstnum = numbers[0];
Console.WriteLine("Element at first index position:- " + firstnum + "\n\n");

//printing the array on command line.
Console.Write("The Array is:- ");
for (int i = 0; i <= numbers.Length-1; i++) 
{
    Console.Write(numbers[i] + " ");
}

//modifying the element
numbers[4] = 6;
numbers[3] = 5;

//printing the array Again After the Modification
Console.Write("\n\nThe Modified Array is:- ");
for (int i = 0; i <= numbers.Length - 1; i++)
{
    Console.Write(numbers[i] + " ");
}
Console.WriteLine("\n\n_________________________________________________");
Console.WriteLine("_________________________________________________\n\n");

// Working with List 
List<string> names = new List<String>(); //Initializing List
// Now Storing data in List
names.Add("Om");
names.Add("Bhakti");
names.Add("Sai");

Console.WriteLine("******** Now Working with List ********\n\nThe Elements in List:- ");
Console.Write(names[0] + " ");
Console.Write(names[1] + " ");
Console.Write(names[2] + " \n");

//Modifying Elements 
names[0] = "Abhay";
names[1] = "Amol";
names[2] = "Rupali";

// priting all elements by a loop
Console.WriteLine("\n\nModified Elements in List:- ");
foreach (var item in names)
{
    Console.Write(item + " ");
}
// get the count of elements in list
int count = names.Count;
Console.WriteLine($"\nThe Count of elements present in List is {count}");
Console.WriteLine("\n\n_________________________________________________");
Console.WriteLine("_________________________________________________\n\n");
