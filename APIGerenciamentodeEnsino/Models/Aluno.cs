namespace APIGerenciamentodeEnsino.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Genero { get; set; }
        public int TotalFaltas { get; set; }
        public int TurmaId { get; set; }

    }
    
}
