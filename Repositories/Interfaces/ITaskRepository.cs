using BoardSystem.Domains;
using BoardSystem.Enums;

namespace BoardSystem.Repositories.Interfaces
{
    public interface ITaskRepository : IRepository<Tasks>
    {
        IEnumerable<Tasks> GetAllTasks();
        Tasks? GetTaskById(int id);
        IEnumerable<Tasks> GetTaskByStatus(TasksStatus status);
        IEnumerable<Tasks> GetTaskByBoardId(int id);
    }
}
