using Vinyl.TaskPlanner.DataAccess.Abstractions;
using Vinyl.TaskPlanner.Domain.Models;
using Moq;
using Vinyl.TaskPlanner.Domain.Models.Enums;

namespace Vinyl.TaskPlanner.Domain.Logic.Tests
{
    public class SimpleTaskPlannerTests
    {
        [Fact]
        public void CreatePlan_SortsTasksByPriorityDueDateAndTitle()
        {
            var repositoryMock = new Mock<IWorkItemsRepository>();
            repositoryMock.Setup(repo => repo.GetAll())
                .Returns(new[]
                {
                    new WorkItem { Priority = Priority.High, DueDate = DateTime.Now.AddDays(1), Title = "Task C" },
                    new WorkItem { Priority = Priority.Medium, DueDate = DateTime.Now.AddDays(3), Title = "Task A" },
                    new WorkItem { Priority = Priority.Low, DueDate = DateTime.Now.AddDays(2), Title = "Task B" }
                });

            var taskPlanner = new SimpleTaskPlanner(repositoryMock.Object);

            var result = taskPlanner.CreatePlan();

            Assert.Equal("Task C", result[0].Title);
            Assert.Equal("Task B", result[1].Title);
            Assert.Equal("Task A", result[2].Title);
        }

        [Fact]
        public void CreatePlan_IgnoresCompletedTasks()
        {
            var repositoryMock = new Mock<IWorkItemsRepository>();
            repositoryMock.Setup(repo => repo.GetAll())
                .Returns(new[]
                {
                    new WorkItem { IsCompleted = false },
                    new WorkItem { IsCompleted = true },
                    new WorkItem { IsCompleted = false }
                });

            var taskPlanner = new SimpleTaskPlanner(repositoryMock.Object);

            var result = taskPlanner.CreatePlan();

            Assert.All(result, item => Assert.False(item.IsCompleted));
        }
    }
}
