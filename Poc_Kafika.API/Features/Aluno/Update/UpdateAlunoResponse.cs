namespace Poc_Kafika.API.Features.Aluno.Update
{
    public class UpdateAlunoResponse(Guid id, string nome, string disciplina, decimal nota) 
        : AlunoResponse(id, nome, disciplina, nota)
    {
    }
}
