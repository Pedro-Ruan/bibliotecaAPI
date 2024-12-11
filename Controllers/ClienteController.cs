using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotecaAPI.Data;
using bibliotecaAPI.Models;
using bibliotecaAPI.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace bibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private static List<Cliente> Clientes = new List<Cliente>(){
            new Cliente(){Id=1,Nome="Pedro", Cpf="12345678911", Email="pedro@exemplo.com",Telefone="11123456789"},
            new Cliente(){Id=2,Nome="Mariane", Cpf="12345678917",Email="mariane@exemplo.com",Telefone="11234567891"},
            new Cliente(){Id=3,Nome="Ronaldo",Cpf="72031921232",Email="ronaldo@exemplo.com",Telefone="11345678912"},
            new Cliente(){Id=4,Nome="Sandra",Cpf="57689231345",Email="sandra@exemplo.com",Telefone="11456789123"},
            new Cliente(){Id=5,Nome="Felipe",Cpf="43827516491",Email="felipe@exemplo.com",Telefone="11567891234"},
            new Cliente(){Id=6,Nome="Rebecca",Cpf="92876415367",Email="rebecca@exemplo.com",Telefone="11678912345"},
            new Cliente(){Id=7,Nome="Guilherme",Cpf="57918364720",Email="guilherme@exemplo.com",Telefone="11789123456"},
            new Cliente(){Id=8,Nome="Camily",Cpf="21834675911",Email="camily@exemplo.com",Telefone="11891234567"},
            new Cliente(){Id=9,Nome="Wesley",Cpf="76389125430",Email="wesley@exemplo.com",Telefone="11912345678"},
            new Cliente(){Id=10,Nome="Fernanda",Cpf="94527681307",Email="fernanda@exemplo.com",Telefone="11987654321"}
        };

        [HttpGet("GetAll")]

        public async Task<IActionResult> ListarClientes (){

            var clientes = await _context.TB_Cliente.ToListAsync();
            return Ok(clientes);

        }

        private readonly DataContext _context;

        public ClienteController(DataContext context){
            _context = context;
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCliente (int id){

         var cliente = await _context.TB_Cliente.FindAsync(id);
         if(cliente == null)
         return NotFound("Cliente não encontrado");

         return Ok(cliente);



        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente(Cliente cliente)
        {
            if (await ClienteExistente(cliente.Nome))
            {
        return BadRequest("Cliente já existe.");
            }

        _context.TB_Cliente.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(int id, Cliente clienteAtualizado)
        {
            var cliente = await _context.TB_Cliente.FindAsync(id);
            if(cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;
            cliente.Telefone = clienteAtualizado.Telefone;

            _context.TB_Cliente.Update(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCliente(int id)
        {
            var cliente = await _context.TB_Cliente.FindAsync(id);
            if(cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _context.TB_Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> ClienteExistente(string NomeCliente){

            if(await _context.TB_Cliente.AnyAsync(x => x.Nome.ToLower() == NomeCliente.ToLower())){
                return true;

            }
            else{
                return false;
            }
        }
        

    }

}