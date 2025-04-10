namespace Poc_Kafika.API.Features.Aluno;

public class AlunoResponse(Guid id, string nome, string disciplina, decimal nota)
{
    public static AlunoResponse Create(Guid id, string nome, string disciplina, decimal nota) =>
            new(id, nome, disciplina, nota);

    public Guid Id { get; private set; } = id;
    public string Nome { get; private set; } = nome;
    public string Disciplina { get; private set; } = disciplina;
    public decimal Nota { get; private set; } = nota;
}
