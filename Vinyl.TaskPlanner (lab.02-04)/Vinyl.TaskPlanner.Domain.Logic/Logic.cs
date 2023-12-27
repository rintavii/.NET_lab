using Vinyl.TaskPlanner.Domain.Models;
using Vinyl.TaskPlanner.DataAccess.Abstractions;

namespace Vinyl.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        private readonly IWorkItemsRepository _repository;

        public SimpleTaskPlanner(IWorkItemsRepository repository)
        {
            _repository = repository;
        }

        public WorkItem[] CreatePlan()
        {
            var items = _repository.GetAll();
            return items;
        }
    }
}
