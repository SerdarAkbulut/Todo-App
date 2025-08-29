using Crud_işlemleri.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crud_işlemleri.Data
{
    public class DataContext:IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasMany(u => u.Todos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Todo>()
          .HasOne(t => t.User)
          .WithMany(u => u.Todos)
          .HasForeignKey(t => t.UserId)
          .IsRequired();
        }
    }
}
