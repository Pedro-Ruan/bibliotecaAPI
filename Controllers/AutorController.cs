using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using bibliotecaAPI.Data;
using bibliotecaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bibliotecaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {

        private readonly DataContext _context;  
        public AutorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> ListarAutores()
        {

            var autores = await _context.TB_Autor.ToListAsync();
            return Ok(autores);

        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAutor (int id){

         var autor = await _context.TB_Autor.FindAsync(id);
         if(autor == null)
         return NotFound("Autor não encontrado");

         return Ok(autor);

        }

        [HttpPost("RegistrarAutor")]
        public async Task<IActionResult> CriarAutor(Autor autor)
        {
            if (await AutorExistente(autor.Nome))
            {
        return BadRequest("Autor já existe.");
            }

        _context.TB_Autor.Add(autor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarAutor), new { id = autor.Id }, autor);
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAutor(int id, Autor autorAtualizado)
        {
            var autor = await _context.TB_Autor.FindAsync(id);
            if(autor == null)
            {
                return NotFound("Autor não encontrado");
            }

            autor.Nome = autorAtualizado.Nome;
            autor.Biografia = autorAtualizado.Biografia;
        

            _context.TB_Autor.Update(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverAutor(int id)
        {
            var autor = await _context.TB_Autor.FindAsync(id);
            if(autor == null)
            {
                return NotFound("Autor não encontrado");
            }

            _context.TB_Autor.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> AutorExistente(string nome)
        {
            return await _context.TB_Autor.AnyAsync(a => a.Nome == nome);
        }


    }
}