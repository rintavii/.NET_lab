using System;
using Vinyl.TaskPlanner.Domain.Logic;
using Vinyl.TaskPlanner.Domain.Models;
using Vinyl.TaskPlanner.Domain.Models.Enums;

internal static class Program
{
    public static void Main(string[] args)
    {
  
        var taskPlanner = new SimpleTaskPlanner();

        var workItems = new WorkItem[]
        {
            new WorkItem { Title = "Task 1", DueDate = DateTime.Now.AddDays(3), Priority = Priority.High },
            new WorkItem { Title = "Task 2", DueDate = DateTime.Now.AddDays(1), Priority = Priority.Medium },
            new WorkItem { Title = "Task 3", DueDate = DateTime.Now.AddDays(2), Priority = Priority.Urgent }
        };

        var sortedWorkItems = taskPlanner.CreatePlan(workItems);

        foreach (var item in sortedWorkItems)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}

