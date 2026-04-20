using BoardSystem.Domains;

namespace BoardSystem.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetAllComments();
        IEnumerable<Comment> GetCommentsByTaskId(int id);
        Comment? GetCommentById(int id);
    }
}
