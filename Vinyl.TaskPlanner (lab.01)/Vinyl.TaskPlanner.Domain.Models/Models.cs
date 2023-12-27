﻿using Vinyl.TaskPlanner.Domain.Models.Enums;
using System;

namespace Vinyl.TaskPlanner.Domain.Models.Enums
{
    public enum Priority
    {
        None,
        Low,
        Medium,
        High,
        Urgent
    }
}

namespace Vinyl.TaskPlanner.Domain.Models.Enums
{
    public enum Complexity
    {
        None,
        Minutes,
        Hours,
        Days,
        Weeks
    }
}


namespace Vinyl.TaskPlanner.Domain.Models
{
    public class WorkItem
    {
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{Title}: due {DueDate.ToString("dd.MM.yyyy")}, {Priority.ToString().ToLower()} priority";
        }
    }
}
