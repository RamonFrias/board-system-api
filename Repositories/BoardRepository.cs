using BoardSystem.Context;
using BoardSystem.Domains;
using BoardSystem.Repositories.Interfaces;

namespace BoardSystem.Repositories
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {
        public BoardRepository(ApiDbContext context) : base(context)
        {
        }

        public IEnumerable<Board> GetAllBoards()
        {
            var boards = GetAll().ToList();
            return boards;
        }

        public Board? GetBoardById(int id)
        {
            var board = GetByFilter(b => b.Id == id);
            return board;
        }

        public IEnumerable<Board> GetCommentsByUserId(int id)
        {
            var boards = GetAll().Where(b => b.UserId == id).ToList();
            return boards;
        }
    }
}
