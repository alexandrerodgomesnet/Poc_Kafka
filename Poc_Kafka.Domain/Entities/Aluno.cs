namespace Poc_Kafka.Domain.Entities;

public class Aluno
{
    public Aluno(string nome, string disciplina, decimal nota)
    {
        Nome = nome;
        Disciplina = disciplina;
        Nota = nota;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Disciplina { get; set; } = string.Empty;
    public decimal Nota { get; set; }

    public static Aluno Create(string nome, string disciplina, decimal nota) => new(nome, disciplina, nota);
}
