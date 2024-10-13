using LibManage.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibManage.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Loans)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Loans)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookId);


                        //            modelBuilder.Entity<User>()
                        //.HasOne(u => u.Address) // Um usuário tem um endereço
                        //.WithOne(a => a.User)   // Um endereço pertence a um único usuário
                        //.HasForeignKey<Address>(a => a.UserId); // Chave estrangeira em Address que referencia o Id de User


            //            modelBuilder.Entity<User>()
            //.HasMany(u => u.Posts)  // Um usuário tem muitas postagens
            //.WithOne(p => p.User)   // Cada postagem pertence a um único usuário
            //.HasForeignKey(p => p.UserId); // Chave estrangeira em Postagem que referencia o Id do Usuário


            //                .HasMany(u => u.Courses)  // Um usuário tem muitos cursos
            //.WithMany(c => c.Users);  // Um curso tem muitos usuários


        }
    }
}
