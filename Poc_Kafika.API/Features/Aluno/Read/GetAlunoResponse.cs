
namespace Poc_Kafika.API.Features.Aluno.Read
{
    public class GetAlunoResponse(Guid id, string nome, string disciplina, decimal nota) 
        : AlunoResponse(id, nome, disciplina, nota)
    {
    }
}
