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
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }


        public WorkItem Clone()
        {
            return new WorkItem
            {
                Id = Guid.NewGuid(),
                CreationDate = this.CreationDate,
                DueDate = this.DueDate,
                Priority = this.Priority,
                Complexity = this.Complexity,
                Title = this.Title,
                Description = this.Description,
                IsCompleted = this.IsCompleted
            };
        }


        public override string ToString()
        {
            return $"{Title}: due {DueDate.ToString("dd.MM.yyyy")}, {Priority.ToString().ToLower()} priority";
        }
    }
}
