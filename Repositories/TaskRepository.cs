using BoardSystem.Context;
using BoardSystem.Domains;
using BoardSystem.Enums;
using BoardSystem.Repositories.Interfaces;

namespace BoardSystem.Repositories
{
    public class TaskRepository : Repository<Tasks>, ITaskRepository
    {
        public TaskRepository(ApiDbContext context) : base(context) { }

        public IEnumerable<Tasks> GetAllTasks()
        {
            var tasks = GetAll().ToList();
            return tasks;
        }

        public IEnumerable<Tasks> GetTaskByBoardId(int id)
        {
            var tasks = GetAll().Where(t => t.BoardId == id).ToList();
            return tasks;
        }

        public Tasks? GetTaskById(int id)
        {
            var task = GetByFilter(t => t.Id == id);
            return task;
        }

        public IEnumerable<Tasks> GetTaskByStatus(TasksStatus status)
        {
            var task = GetAll().Where(t => t.Status == status).ToList();
            return task;
        }
    }
}
