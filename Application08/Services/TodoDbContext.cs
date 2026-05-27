using Microsoft.EntityFrameworkCore;

namespace Application08.Services
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
