using System;
using Vinyl.TaskPlanner.DataAccess;
using Vinyl.TaskPlanner.DataAccess.Abstractions;
using Vinyl.TaskPlanner.Domain.Logic;
using Vinyl.TaskPlanner.Domain.Models;


internal static class ConsoleRunner
{
    private static readonly IWorkItemsRepository Repository = new FileWorkItemsRepository();
    private static readonly SimpleTaskPlanner TaskPlanner = new SimpleTaskPlanner(Repository);

    public static void Main(string[] args)
    {
        Console.WriteLine("Task Planner Console App");

        while (true)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("[A]dd work item");
            Console.WriteLine("[B]uild a plan");
            Console.WriteLine("[M]ark work item as completed");
            Console.WriteLine("[R]emove a work item");
            Console.WriteLine("[Q]uit the app");

            var choice = Console.ReadLine()?.ToUpper();
            switch (choice)
            {
                case "A":
                    AddWorkItem();
                    break;
                case "B":
                    BuildPlan();
                    break;
                case "M":
                    MarkCompleted();
                    break;
                case "R":
                    RemoveWorkItem();
                    break;
                case "Q":
                    Console.WriteLine("Quitting the app.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void AddWorkItem()
    {
        Console.WriteLine("Enter work item details:");

        Console.Write("Title: ");
        var title = Console.ReadLine();


        var newWorkItem = new WorkItem
        {
            Title = title,

        };

        var id = Repository.Add(newWorkItem);
        Console.WriteLine($"Work item added with ID: {id}");
    }

    private static void BuildPlan()
    {
        var plan = TaskPlanner.CreatePlan();
        Console.WriteLine("Work Plan:");
        foreach (var item in plan)
        {
            Console.WriteLine(item);
        }
    }

    private static void MarkCompleted()
    {
        Console.WriteLine("Enter the ID of the work item to mark as completed:");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            var workItem = Repository.Get(id);
            if (workItem != null)
            {
                workItem.IsCompleted = true;
                Repository.Update(workItem);
                Console.WriteLine("Work item marked as completed.");
            }
            else
            {
                Console.WriteLine("Work item not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    private static void RemoveWorkItem()
    {
        Console.WriteLine("Enter the ID of the work item to remove:");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            if (Repository.Remove(id))
            {
                Console.WriteLine("Work item removed successfully.");
            }
            else
            {
                Console.WriteLine("Work item not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}
