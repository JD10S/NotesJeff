using Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class NoteDBContext: DbContext{


        public NoteDBContext(DbContextOptions<NoteDBContext> options) : base(options)
        {
        }

        // DbSet properties para tus entidades
        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        //Relacionamos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne<User>(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.IdUser);

            modelBuilder.Entity<Note>()
                .HasOne<Category>(n => n.Category)
                .WithMany(c => c.Notes)
                .HasForeignKey(n => n.IdCategory);
        }
    }
}
