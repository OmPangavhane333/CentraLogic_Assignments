using System;
using System.Collections.Generic;

class Item
{
    public int ID { get; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Item(int id, string name, double price, int quantity)
    {
        ID = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

class Inventory
{
    private List<Item> items;
    private Random random;

    public Inventory()
    {
        items = new List<Item>();
        random = new Random();
    }

    public void AddItem(string name, double price, int quantity)
    {
        int nextId = GenerateNextItemId();
        Item newItem = new Item(nextId, name, price, quantity);
        items.Add(newItem);
        Console.WriteLine("Item added successfully!");
    }

    public void DisplayAllItems()
    {
        Console.WriteLine("\nAll Items in Inventory:");
        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
        }
    }

    public void FindItemById(int id)
    {
        Item foundItem = items.Find(item => item.ID == id);
        if (foundItem != null)
        {
            Console.WriteLine($"Item found - ID: {foundItem.ID}, Name: {foundItem.Name}, Price: {foundItem.Price}, Quantity: {foundItem.Quantity}");
        }
        else
        {
            Console.WriteLine("Item not found!");
        }
    }

    public void UpdateItem(int id, string name, double price, int quantity)
    {
        Item foundItem = items.Find(item => item.ID == id);
        if (foundItem != null)
        {
            foundItem.Name = name;
            foundItem.Price = price;
            foundItem.Quantity = quantity;
            Console.WriteLine("Item updated successfully!");
        }
        else
        {
            Console.WriteLine("Item not found!");
        }
    }

    public void DeleteItem(int id)
    {
        Item foundItem = items.Find(item => item.ID == id);
        if (foundItem != null)
        {
            items.Remove(foundItem);
            Console.WriteLine("Item deleted successfully!");
        }
        else
        {
            Console.WriteLine("Item not found!");
        }
    }

    private int GenerateNextItemId()
    {
        return random.Next(1000, 9999); // You can customize the range for your unique IDs
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("----------- Week 3 CentraLogic -----------\nDone By:- Om Pangavhane\n");
        Inventory inventory = new Inventory();
        int choice;

        do
        {
            Console.WriteLine("\nInventory Management System Menu:");
            Console.WriteLine("1. Add a new item");
            Console.WriteLine("2. Display all items");
            Console.WriteLine("3. Find an item by ID");
            Console.WriteLine("4. Update an item's information");
            Console.WriteLine("5. Delete an item");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Enter a numeric value: ");
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter item name: ");
                    string itemName = Console.ReadLine();
                    Console.Write("Enter item price: ");
                    double itemPrice;
                    while (!double.TryParse(Console.ReadLine(), out itemPrice))
                    {
                        Console.Write("Invalid input. Enter a numeric value for price: ");
                    }
                    Console.Write("Enter item quantity: ");
                    int itemQuantity;
                    while (!int.TryParse(Console.ReadLine(), out itemQuantity))
                    {
                        Console.Write("Invalid input. Enter a numeric value for quantity: ");
                    }
                    inventory.AddItem(itemName, itemPrice, itemQuantity);
                    break;

                case 2:
                    inventory.DisplayAllItems();
                    break;

                case 3:
                    Console.Write("Enter item ID to find: ");
                    int findId;
                    while (!int.TryParse(Console.ReadLine(), out findId))
                    {
                        Console.Write("Invalid input. Enter a numeric value for ID: ");
                    }
                    inventory.FindItemById(findId);
                    break;

                case 4:
                    Console.Write("Enter item ID to update: ");
                    int updateId;
                    while (!int.TryParse(Console.ReadLine(), out updateId))
                    {
                        Console.Write("Invalid input. Enter a numeric value for ID: ");
                    }
                    Console.Write("Enter updated item name: ");
                    string updatedName = Console.ReadLine();
                    Console.Write("Enter updated item price: ");
                    double updatedPrice;
                    while (!double.TryParse(Console.ReadLine(), out updatedPrice))
                    {
                        Console.Write("Invalid input. Enter a numeric value for price: ");
                    }
                    Console.Write("Enter updated item quantity: ");
                    int updatedQuantity;
                    while (!int.TryParse(Console.ReadLine(), out updatedQuantity))
                    {
                        Console.Write("Invalid input. Enter a numeric value for quantity: ");
                    }
                    inventory.UpdateItem(updateId, updatedName, updatedPrice, updatedQuantity);
                    break;

                case 5:
                    Console.Write("Enter item ID to delete: ");
                    int deleteId;
                    while (!int.TryParse(Console.ReadLine(), out deleteId))
                    {
                        Console.Write("Invalid input. Enter a numeric value for ID: ");
                    }
                    inventory.DeleteItem(deleteId);
                    break;

                case 6:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }

        } while (choice != 6);
    }
}