using BoardSystem.Context;
using BoardSystem.Domains;
using BoardSystem.Repositories.Interfaces;

namespace BoardSystem.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApiDbContext context) : base(context)
        {
        }

        public IEnumerable<Comment> GetAllComments()
        {
            var comments = GetAll().ToList();
            return comments;
        }

        public Comment? GetCommentById(int id)
        {
            var comment = GetByFilter(c => c.Id == id);
            return comment;
        }

        public IEnumerable<Comment> GetCommentsByTaskId(int id)
        {
            var comments = GetAll().Where(c => c.TaskId == id).ToList();
            return comments;
        }
    }
}
