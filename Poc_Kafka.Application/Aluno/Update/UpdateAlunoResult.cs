namespace Poc_Kafka.Application.Aluno.Update;

public class UpdateAlunoResult(Guid id, string nome, string disciplina, decimal nota) 
    : AlunoResult(id, nome, disciplina, nota)
{
    public static UpdateAlunoResult Create(Guid id, string nome, string disciplina, decimal nota) =>
        new(id, nome, disciplina, nota);
}
