using BoardSystem.Domains;
using Microsoft.EntityFrameworkCore;

namespace BoardSystem.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
