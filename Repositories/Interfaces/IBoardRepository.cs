using BoardSystem.Domains;

namespace BoardSystem.Repositories.Interfaces
{
    public interface IBoardRepository : IRepository<Board>
    {
        IEnumerable<Board> GetAllBoards();
        IEnumerable<Board> GetCommentsByUserId(int id);
        Board? GetBoardById(int id);
    }
}
