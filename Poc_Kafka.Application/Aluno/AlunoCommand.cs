namespace Poc_Kafka.Application.Aluno;

public class AlunoCommand(string nome, string disciplina, decimal nota)
{
    public string Nome { get; set; } = nome;
    public string Disciplina { get; set; } = disciplina;
    public decimal Nota { get; set; } = nota;
}
