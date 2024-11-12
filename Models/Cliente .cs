using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bibliotecaAPI.Models
{
    public class Cliente 
    {
       public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int? Longitude { get; set; }
        public int? Latitude { get; set; }
        public int? DataNascimento { get; set; }
        public string? Email { get; set; }
         [JsonIgnore]
        public byte[]? PasswordHash { get; set; }
        [JsonIgnore]
        public byte[]? PasswordSalt { get; set; }

        [NotMapped]
        public string? PassowordString { get; set; }


    }
}