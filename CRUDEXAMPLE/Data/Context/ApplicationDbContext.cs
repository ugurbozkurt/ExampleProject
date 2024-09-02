using CRUDEXAMPLE.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDEXAMPLE.Data.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskData> Tasks { get; set; }
    }
}
