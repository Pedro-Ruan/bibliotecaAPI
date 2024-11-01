using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bibliotecaAPI.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public int IdAutor { get; set; } 
        public string Nome { get; set;}
        
        [JsonIgnore]
        public Autor Autor { get; set; } = null;
        public string Editora { get; set; }
        public double Preco { get; set; }
        public int QtdPaginas { get; set; }

       // public List<Alugar> Alugar { get; set; } = new List<Alugar> ();
    }

    

    


}
