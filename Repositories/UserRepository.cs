using BoardSystem.Context;
using BoardSystem.Domains;
using BoardSystem.Repositories.Interfaces;

namespace BoardSystem.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApiDbContext _context) : base(_context) { }

        public IEnumerable<User> GetAllUsers()
        {
            var users = GetAll().ToList();
            return users;
        }

        public User? GetUserByEmail(string email)
        {
            var user = GetByFilter(u => u.Email == email);
            return user;
        }

        public User? GetUserById(int id)
        {
            var user = GetByFilter(u => u.Id == id);
            return user;
        }
    }
}
