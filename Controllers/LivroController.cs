using System;
using System.Collections.Generic;
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
    public class LivroController : ControllerBase
    {
        private readonly DataContext _context;

        public LivroController(DataContext context)
        {
            _context = context; 
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarLivros()
        {
            var livros = await _context.TB_Livro
                                       .Include(l => l.Autor)
                                       .ToListAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarLivro(int id)
        {
            var livro = await _context.TB_Livro
                                      .Include(l => l.Autor)
                                      .FirstOrDefaultAsync(l => l.Id == id);
            if (livro == null)
            {
                return NotFound("Livro não encontrado.");
            }
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> CriarLivro(Livro livro)
        {
            if (livro == null)
            {
                return BadRequest("Dados do livro inválidos.");
            }

            _context.TB_Livro.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarLivro), new { id = livro.Id }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivro(int id, Livro livroAtualizado)
        {
            if (id != livroAtualizado.Id)
            {
                return BadRequest("IDs não correspondem.");
            }

            _context.Entry(livroAtualizado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLivro(int id)
        {
            var livro = await _context.TB_Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound("Livro não encontrado.");
            }

            _context.TB_Livro.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
