using Blog.Core;
using Blog.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }



    }
}
