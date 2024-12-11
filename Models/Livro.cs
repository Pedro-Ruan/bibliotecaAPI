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
        public string Titulo { get; set;}
        public int IdAutor { get; set; } 

        [JsonIgnore]
        public Autor Autor { get; set; }
        public int QuantidadeDisponivel { get; set; }


        
        
    }

    

    


}
