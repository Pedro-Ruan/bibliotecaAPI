using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotecaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Livro> TB_Livro { get; set; }
        public DbSet<Autor> TB_Autor { get; set; }
        public DbSet<Cliente> TB_Cliente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Livro>().ToTable("TB_Livro");
            modelBuilder.Entity<Autor>().ToTable("TB_Autor");
            modelBuilder.Entity<Cliente>().ToTable("TB_Cliente");


            //Relacionamento entre Autor e Livro(um autor pode ter N livros)
            modelBuilder.Entity<Livro>()
            .HasOne(l => l.Autor)
            .WithMany(a => a.Livros)
            .HasForeignKey(l => l.IdAutor);

            modelBuilder.Entity<Cliente>()
            .HasData(

            new Cliente() { Id = 1, Nome = "Pedro", Cpf = "12345678911", Email = "pedro@exemplo.com", Telefone = "11123456789" },
            new Cliente() { Id = 2, Nome = "Mariane", Cpf = "12345678917", Email = "mariane@exemplo.com", Telefone = "11234567891" },
            new Cliente() { Id = 3, Nome = "Ronaldo", Cpf = "72031921232", Email = "ronaldo@exemplo.com", Telefone = "11345678912" },
            new Cliente() { Id = 4, Nome = "Sandra", Cpf = "57689231345", Email = "sandra@exemplo.com", Telefone = "11456789123" },
            new Cliente() { Id = 5, Nome = "Felipe", Cpf = "43827516491", Email = "felipe@exemplo.com", Telefone = "11567891234" },
            new Cliente() { Id = 6, Nome = "Rebecca", Cpf = "92876415367", Email = "rebecca@exemplo.com", Telefone = "11678912345" },
            new Cliente() { Id = 7, Nome = "Guilherme", Cpf = "57918364720", Email = "guilherme@exemplo.com", Telefone = "11789123456" },
            new Cliente() { Id = 8, Nome = "Camily", Cpf = "21834675911", Email = "camily@exemplo.com", Telefone = "11891234567" },
            new Cliente() { Id = 9, Nome = "Wesley", Cpf = "76389125430", Email = "wesley@exemplo.com", Telefone = "11912345678" },
            new Cliente() { Id = 10, Nome = "Fernanda", Cpf = "94527681307", Email = "fernanda@exemplo.com", Telefone = "11987654321" }


            );

            modelBuilder.Entity<Livro>().HasData(
       new Livro { Id = 1, Titulo = "Livro A", IdAutor = 1, QuantidadeDisponivel = 10 },
       new Livro { Id = 2, Titulo = "Livro B", IdAutor = 2, QuantidadeDisponivel = 5 },
       new Livro { Id = 3, Titulo = "Livro C", IdAutor = 3, QuantidadeDisponivel = 8 },
       new Livro { Id = 4, Titulo = "Livro D", IdAutor = 4, QuantidadeDisponivel = 3 },
       new Livro { Id = 5, Titulo = "Livro E", IdAutor = 5, QuantidadeDisponivel = 6 },
       new Livro { Id = 6, Titulo = "Livro F", IdAutor = 1, QuantidadeDisponivel = 7 },
       new Livro { Id = 7, Titulo = "Livro G", IdAutor = 2, QuantidadeDisponivel = 4 },
       new Livro { Id = 8, Titulo = "Livro H", IdAutor = 3, QuantidadeDisponivel = 9 },
       new Livro { Id = 9, Titulo = "Livro I", IdAutor = 4, QuantidadeDisponivel = 5 },
       new Livro { Id = 10, Titulo = "Livro J", IdAutor = 5, QuantidadeDisponivel = 6 },
       new Livro { Id = 11, Titulo = "Livro K", IdAutor = 1, QuantidadeDisponivel = 8 },
       new Livro { Id = 12, Titulo = "Livro L", IdAutor = 2, QuantidadeDisponivel = 7 },
       new Livro { Id = 13, Titulo = "Livro M", IdAutor = 3, QuantidadeDisponivel = 6 },
       new Livro { Id = 14, Titulo = "Livro N", IdAutor = 4, QuantidadeDisponivel = 10 },
       new Livro { Id = 15, Titulo = "Livro O", IdAutor = 5, QuantidadeDisponivel = 4 },
       new Livro { Id = 16, Titulo = "Livro P", IdAutor = 1, QuantidadeDisponivel = 5 },
       new Livro { Id = 17, Titulo = "Livro Q", IdAutor = 2, QuantidadeDisponivel = 8 },
       new Livro { Id = 18, Titulo = "Livro R", IdAutor = 3, QuantidadeDisponivel = 7 },
       new Livro { Id = 19, Titulo = "Livro S", IdAutor = 4, QuantidadeDisponivel = 9 },
       new Livro { Id = 20, Titulo = "Livro T", IdAutor = 5, QuantidadeDisponivel = 6 }
   );
            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nome = "Autor 1", Cpf = "12345678911", Biografia = "Biografia do Autor 1" },
                new Autor { Id = 2, Nome = "Autor 2", Cpf = "12345678917", Biografia = "Biografia do Autor 2" },
                new Autor { Id = 3, Nome = "Autor 3", Cpf = "72031921232", Biografia = "Biografia do Autor 3" },
                new Autor { Id = 4, Nome = "Autor 4", Cpf = "57689231345", Biografia = "Biografia do Autor 4" },
                new Autor { Id = 5, Nome = "Autor 5", Cpf = "43827516491", Biografia = "Biografia do Autor 5" },
                new Autor { Id = 6, Nome = "Autor 6", Cpf = "92876415367", Biografia = "Biografia do Autor 6" },
                new Autor { Id = 7, Nome = "Autor 7", Cpf = "57918364720", Biografia = "Biografia do Autor 7" },
                new Autor { Id = 8, Nome = "Autor 8", Cpf = "21834675911", Biografia = "Biografia do Autor 8" },
                new Autor { Id = 9, Nome = "Autor 9", Cpf = "76389125430", Biografia = "Biografia do Autor 9" },
                new Autor { Id = 10, Nome = "Autor 10", Cpf = "94527681307", Biografia = "Biografia do Autor 10" },
                new Autor { Id = 11, Nome = "Autor 11", Cpf = "19283746513", Biografia = "Biografia do Autor 11" },
                new Autor { Id = 12, Nome = "Autor 12", Cpf = "10928374650", Biografia = "Biografia do Autor 12" },
                new Autor { Id = 13, Nome = "Autor 13", Cpf = "38472916342", Biografia = "Biografia do Autor 13" },
                new Autor { Id = 14, Nome = "Autor 14", Cpf = "72983146129", Biografia = "Biografia do Autor 14" },
                new Autor { Id = 15, Nome = "Autor 15", Cpf = "28934716283", Biografia = "Biografia do Autor 15" },
                new Autor { Id = 16, Nome = "Autor 16", Cpf = "73912847301", Biografia = "Biografia do Autor 16" },
                new Autor { Id = 17, Nome = "Autor 17", Cpf = "49283756109", Biografia = "Biografia do Autor 17" },
                new Autor { Id = 18, Nome = "Autor 18", Cpf = "59283746012", Biografia = "Biografia do Autor 18" },
                new Autor { Id = 19, Nome = "Autor 19", Cpf = "12938475603", Biografia = "Biografia do Autor 19" },
                new Autor { Id = 20, Nome = "Autor 20", Cpf = "58374612937", Biografia = "Biografia do Autor 20" }
            );

        }









    }

}
