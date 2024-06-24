using Microsoft.EntityFrameworkCore;
using Model;

namespace Project.Data{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Todo> Todos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>(entity => {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).IsRequired();
                entity.Property(t => t.description).IsRequired();
                entity.Property(t => t.CreatedAt).IsRequired();
                entity.Property(t => t.DueDate);
            });
        }
    }
}
