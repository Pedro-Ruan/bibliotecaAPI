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
        public DataContext(DbContextOptions<DataContext> opitions) : base(opitions)
        {

        }

        public DbSet<Livro> TB_Livro { get; set; }
        public DbSet<Autor> TB_Autor { get; set; }

        public DbSet<Alugar> TB_Alugar { get; set; }

        public DbSet<Cliente> TB_Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("TB_Livro");
            modelBuilder.Entity<Autor>().ToTable("TB_Autor");
            modelBuilder.Entity<Cliente>().ToTable("TB_Cliente");
            modelBuilder.Entity<Alugar>().ToTable("TB_Alugar");

            modelBuilder.Entity<Autor>()
            .HasMany(l => l.Livros)
            .WithOne(a => a.Autor)
            .HasForeignKey(idAu => idAu.IdAutor)
            .IsRequired(false);

             modelBuilder.Entity<Alugar>()
            .HasKey(al => new { al.IdLivro, al.IdCliente });

             modelBuilder.Entity<Livro>().HasData(

                new Livro() { Id = 1, Editora = "PedroBala", IdAutor = 1, Nome = "Harry Potter", Preco = 50, QtdPaginas = 365 }
            );

            modelBuilder.Entity<Autor>().HasData(
            new Autor { Id = 1, Nome = "J.K. Rowling", Cpf = "12345678910", Longitude = 0, Latitude = 0 }
            );

            modelBuilder.Entity<Cliente>().HasData(
             new Cliente() {Id = 1, Nome = "Pedro Ruan", Cpf = "23456789101" },

             new Cliente() { Id=2,Nome="Maribode", Cpf="12345678917"}


            );

            
            modelBuilder.Entity<Alugar>().HasData(

                new Alugar() {IdLivro=1, IdCliente=1, DataLivroAlugado = DateTime.Now},
                new Alugar() {IdLivro = 1, IdCliente=2,DataLivroAlugado = DateTime.Now.AddDays(-1)}

            );





        }

    }
}