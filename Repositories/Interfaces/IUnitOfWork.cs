namespace BoardSystem.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBoardRepository BoardRepository { get; }
        ICommentRepository CommentRepository { get; }
        ITaskRepository TaskRepository { get; }
        void Commit();
        void Dispose();
    }
}
