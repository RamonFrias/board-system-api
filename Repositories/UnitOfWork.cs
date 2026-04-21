using BoardSystem.Context;
using BoardSystem.Repositories.Interfaces;

namespace BoardSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;

        private IBoardRepository _boardRepository;

        private ICommentRepository _commentRepository;

        private ITaskRepository _taskRepository;

        public ApiDbContext _context;

        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public IBoardRepository BoardRepository
        {
            get
            {
                return _boardRepository = _boardRepository ?? new BoardRepository(_context);
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                return _commentRepository = _commentRepository ?? new CommentRepository(_context);
            }
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                return _taskRepository = _taskRepository ?? new TaskRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
