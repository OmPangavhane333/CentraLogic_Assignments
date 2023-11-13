using System.Data;
using System.Runtime.InteropServices;

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
}

class Program {

    static List<Task> tasks = new List<Task>();

    public static void Main(string[] args)
    { 
        bool exit = false;

        while (!exit) 
        {
            Console.WriteLine("\n ****** Task List Menu ******");
            Console.WriteLine("\nHey\n Greetings!!\nChoose Any CRUD Operation to be performed");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");

            Console.Write("Enter Your Option:- ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch) 
            {
                case 1:
                    Create();
                    break;
                case 2:
                    Read();
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    Delete();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Ohhhh...!!\nYour Enter Invalid Number!! Please Try valid option");
                    break;

            }
        }
    
    }
    static void Create() 
    {
        Task newTask = new Task();

        Console.WriteLine("Enter Task Title:- ");
        newTask.Title = Console.ReadLine();

        Console.WriteLine("Enter Tak Description:- ");
        newTask.Description = Console.ReadLine();

        tasks.Add(newTask);
        Console.WriteLine("Yup!!\nYour Task is Created!!");
    }
    static void Read()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Sorry!! \n No Tasks Available.");

        }
        else
        {
            Console.WriteLine("Your Task List:- ");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Title: {task.Title} \n - Description: {task.Description}");
            }
        }
    }
    static void Update()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Sorry!!\nNo tasks available to update.\n First Please Create the Task.");
        }
        else 
        {
            Read();
            Console.WriteLine("Enter Any Index to Update the task");
            int index = Convert.ToInt32(Console.ReadLine());

            if (index >= 0 && index < tasks.Count)
            {
                Console.WriteLine("Enter New Creative Title:- ");
                tasks[index].Title = Console.ReadLine();

                Console.WriteLine("Now Enter Any New creative Description:- ");
                tasks[index].Description = Console.ReadLine();

                Console.WriteLine("***** Yup!! *****\n Your Titke and Description is Updated Successfully!!\n");
            }
            else 
            {
                Console.WriteLine("Sorry!!\n Please Enter Valid Index");
            }

        }
    }
    static void Delete()
    {
        if (tasks.Count == 0) 
        {
            Console.WriteLine("Sorry!!\n No tasks Available to delete!\n First Please Create the Task.");
        }
        else
        {
            Read();
            Console.WriteLine("Enter the index to delete the task:- ");
            int index = Convert.ToInt32(Console.ReadLine());

            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Yup!!\n Your Task Deleted!!");
            }
            else
            {
                Console.WriteLine("Sorry!!\n Please Enter Valid Index");
            }
        }

    }

}