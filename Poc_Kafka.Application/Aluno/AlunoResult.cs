namespace Poc_Kafka.Application.Aluno
{
    public class AlunoResult
    {
        public AlunoResult(Guid id, string nome, string disciplina, decimal nota)
        {
            Id = id;
            Nome = nome;
            Disciplina = disciplina;
            Nota = nota;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Disciplina { get; private set; } = string.Empty;
        public decimal Nota { get; private set; }
    }
}
