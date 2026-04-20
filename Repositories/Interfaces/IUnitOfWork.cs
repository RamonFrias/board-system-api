namespace BoardSystem.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IBoardRepository BoardRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public ITaskRepository TaskRepository { get; }
        void Commit();
        void Dispose();
    }
}
