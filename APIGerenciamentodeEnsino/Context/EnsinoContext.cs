using APIGerenciamentodeEnsino.Models;
using Microsoft.EntityFrameworkCore;

namespace APIGerenciamentodeEnsino.Context
{
    public class EnsinoContext:DbContext
    {
        public EnsinoContext(DbContextOptions<EnsinoContext> options) : base(options)
        {
        }
        //Tabelas definidas no Banco de Dados Escola
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Aluno> Aluno { get; set; }

       
    }
}
