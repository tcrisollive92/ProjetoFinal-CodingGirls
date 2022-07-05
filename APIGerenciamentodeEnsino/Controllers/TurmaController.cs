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
    public class TurmaController : ControllerBase
    {
        private readonly EnsinoContext _context;

        public TurmaController(EnsinoContext context)
        {
            _context = context;
        }

        // GET: api/Turma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurma()
        {
            var Turmas = await _context.Turma.ToListAsync();
            var TurmasAtivas = new List<Turma>();

            if (_context.Turma == null)
            {
                return NotFound("Não há nenhuma turma cadastrada no Banco de Dados Escola.");
            }

            foreach (Turma _turma in Turmas)
            {
                if (_turma.Ativo == true)
                {
                    TurmasAtivas.Add(_turma);
                }
            }
            
            return TurmasAtivas;
        }

        // GET: api/Turma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            if (_context.Turma == null)
            {
                return NotFound($"Não há nenhuma turma cadastrada com TurmaId:{id}.");
            }
            var turma = await _context.Turma.FindAsync(id);

            if (turma == null)
            {
                return NotFound($"Não há nenhuma turma cadastrada com TurmaId:{id}.");
            }

            return turma;
        }

        // PUT: api/Turma/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return BadRequest("Nenhum Id informado para alteração.");
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content($"A atualização do cadastro da turma TurmaId:{id} foi realizada com sucesso!");
        }

        // POST: api/Turma
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
            if (_context.Turma == null)
            {
                return Problem("Entity set 'EnsinoContext.Turma'  is null.");
            }
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurma", new { id = turma.TurmaId }, turma);
        }

        // DELETE: api/Turma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            if (_context.Turma == null)
            {
                return NotFound($"A turma com TurmaId:{id} não foi encontrada no Banco de Dados Escola.");
            }
            else
            {
                var turma = await _context.Turma.FindAsync(id);
                if (turma == null)
                {
                    return NotFound($"A turma com TurmaId:{id} não foi encontrada no Banco de Dados Escola.");
                }
                else
                {
                    List<Aluno> alunosnaturma = await _context.Aluno.ToListAsync();
                    int contador = 0;
                    foreach (Aluno aluno in alunosnaturma)
                    {
                        if (aluno.TurmaId == id) { contador++; }

                    }
                    if(contador > 0) { return Content($"A turma de TurmaId:{id} não pode ser removida pois contém alunos."); }
                    else
                    {
                        _context.Turma.Remove(turma);
                        await _context.SaveChangesAsync();

                        
                    }
                }
               
            }
            return Content($"A turma de TurmaId: {id} foi removida do Banco de Dados Escola com sucesso!");




            /*if (_context.Turma == null)
            {
                return NotFound($"A turma com TurmaId:{id} não foi encontrada no Banco de Dados Escola.");
            }
            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound($"A turma com TurmaId:{id} não foi encontrada no Banco de Dados Escola.");
            }

            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();

            return Content($"A turma de TurmaId: {id} foi removida do Banco de Dados Escola com sucesso!");*/
        }
        private bool TurmaExists(int id)
        {
            return (_context.Turma?.Any(e => e.TurmaId == id)).GetValueOrDefault();
        }
    }
}
