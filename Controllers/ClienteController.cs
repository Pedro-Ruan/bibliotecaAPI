using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotecaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace bibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static List<Cliente> Clientes =  new List<Cliente> (){

           /* new Cliente (){

                Id = 1,
                Nome = "peu",
                Cpf = "1234"
            }*/

        };

        [HttpGet("GetAll")]

        public IActionResult Get (){
            return Ok(Clientes);
        }
    }
}