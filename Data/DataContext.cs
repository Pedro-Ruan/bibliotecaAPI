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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("TB_Livro");
            modelBuilder.Entity<Autor>().ToTable("TB_Autor");

            modelBuilder.Entity<Autor>()
            .HasMany(l => l.Livros)
            .WithOne(a => a.Autor)
            .HasForeignKey(idAu => idAu.IdAutor)
            .IsRequired(false);

            modelBuilder.Entity<Autor>().HasData(
            new Autor { Id = 1, Nome = "J.K. Rowling", Cpf = "12345678900", Longitude = 0, Latitude = 0, DataNascimento = new DateTime(1965, 7, 31) }
            );


            modelBuilder.Entity<Livro>().HasData(

                new Livro() { Id = 1, Editora = "PedroBala", IdAutor = 1, Nome = "Harry Potter", Preco = 50, QtdPaginas = 365 }
            );

            

        }
    }
}