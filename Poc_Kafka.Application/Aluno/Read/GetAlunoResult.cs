namespace Poc_Kafka.Application.Aluno.Read;

public class GetAlunoResult(Guid id, string nome, string disciplina, decimal nota)
    : AlunoResult(id, nome, disciplina, nota)
{
    public static GetAlunoResult Create(Guid id, string nome, string disciplina, decimal nota) =>
        new(id, nome, disciplina, nota);
}
