using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var scheduler = new TaskScheduler<string, int>((task) => Console.WriteLine($"Executing task: {task}"), Comparer<int>.Default.Compare);

        Console.WriteLine("Task Scheduler Menu:");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. Execute Next Task");
        Console.WriteLine("3. View Current Tasks");
        Console.WriteLine("4. View Completed Tasks");
        Console.WriteLine("5. Exit");

        while (true)
        {
            Console.Write("Enter your choice (1-5): ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task and priority (e.g., 'task priority'): ");
                        string input = Console.ReadLine();
                        string task;
                        int priority;
                        if (input.Contains(" ") && int.TryParse(input.Split(' ')[1], out priority))
                        {
                            task = input.Substring(0, input.IndexOf(' '));
                            scheduler.AddTask(task, priority);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter task and priority as specified.");
                        }
                        break;
                    case 2:
                        scheduler.ExecuteNext();
                        break;
                    case 3:
                        scheduler.ViewCurrentTasks();
                        break;
                    case 4:
                        scheduler.ViewCompletedTasks();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
        }
    }
}
