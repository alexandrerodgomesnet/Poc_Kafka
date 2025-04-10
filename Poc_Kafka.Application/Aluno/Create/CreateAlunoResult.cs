namespace Poc_Kafka.Application.Aluno.Create;

public class CreateAlunoResult(Guid id, string nome, string disciplina, decimal nota) 
    : AlunoResult(id, nome, disciplina, nota)
{
    public static CreateAlunoResult Create(Guid id, string nome, string disciplina, decimal nota) =>
        new(id, nome, disciplina, nota);
}
