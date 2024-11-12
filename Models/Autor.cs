using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bibliotecaAPI.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime? DataNascimento { get; set; }

        public List<Livro> Livros { get; set; } = new List<Livro>();


    }



}