using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGerenciamentodeEnsino.Context;
using APIGerenciamentodeEnsino.Models;

namespace APIGerenciamentodeEnsino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly EnsinoContext _context;

        public AlunoController(EnsinoContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {
            if (_context.Aluno == null)
            {
                return NotFound("Não há nenhum aluno cadastrado no Banco de Dados Escola.");
            }
            return await _context.Aluno.ToListAsync();
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            if (_context.Aluno == null)
            {
                return NotFound($"Não há nenhum aluno cadastrado com AlunoId:{id}.");
            }
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound($"Não há nenhum aluno cadastrado com AlunoId:{id}.");
            }

            return aluno;
        }

        // PUT: api/Aluno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return BadRequest("Nenhum Id informado para alteração.");
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content($"A atualização do cadastro do aluno AlunoId:{id} foi realizada com sucesso!");
        }

        // POST: api/Aluno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            if (_context.Aluno == null)
            {
                return Problem("Entity set 'EnsinoContext.Aluno'  is null.");
            }
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.AlunoId }, aluno);
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Aluno == null)
            {
                return NotFound($"O aluno de AlunoId:{id} não foi encontrado no Banco de Dados Escola.");
            }
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound($"O aluno de AlunoId:{id} não foi encontrado no Banco de Dados Escola.");
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return Content($"O aluno de AlunoId: {id} foi deletado do Banco de Dados Escola com sucesso!");
        }

        private bool AlunoExists(int id)
        {
            return (_context.Aluno?.Any(e => e.AlunoId == id)).GetValueOrDefault();
        }

    }
}