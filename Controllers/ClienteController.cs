using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotecaAPI.Data;
using bibliotecaAPI.Models;
using bibliotecaAPI.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private static List<Cliente> Clientes = new List<Cliente>(){
            new Cliente(){Id=1,Nome="Pedro", Cpf="12345678911"},
            new Cliente(){Id=2,Nome="Maribode", Cpf="12345678917"}
        };

        [HttpGet("GetAll")]

        public IActionResult Get (){
            return Ok(Clientes);
        }

        private readonly DataContext _context;

        public ClienteController(DataContext context){
            _context = context;
        }
        


        [HttpGet("{id}")]
        public IActionResult  GetSingle(int id){

            return Ok (Clientes.FirstOrDefault(pe => pe.Id == id));
        }


        private async Task<bool> AlunosExistente(string NomeAluno){

            if(await _context.TB_Cliente.AnyAsync(x => x.Nome.ToLower() == NomeAluno.ToLower())){
                return true;

            }
            else{
                return false;
            }
        }





        [HttpPost("SignUp")]

        public async Task<IActionResult> LoginCLiente(Cliente cliente){

            try{

                if(await ClientesExistente(cliente.Nome))
                throw new System.Exception("Nome de usuário já existe");  

                Criptografia.CriarPasswordHash(cliente.PassowordString, out byte[] hash, out byte[] salt);
                cliente.PassowordString = string.Empty;
                cliente.PasswordHash = hash;
                cliente.PasswordSalt = salt;
                //Adiciona o usuário no banco
                await _context.TB_Cliente.AddAsync(cliente);
                await _context.SaveChangesAsync();

                return Ok(cliente.Id);




            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }

        
    }

        private async Task<bool> ClientesExistente(string nome)
        {
            throw new NotImplementedException();
        }
    }

}