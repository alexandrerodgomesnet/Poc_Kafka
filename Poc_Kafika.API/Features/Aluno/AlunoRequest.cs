namespace Poc_Kafika.API.Features.Aluno;

public class AlunoRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Disciplina { get; set; } = string.Empty;
    public decimal Nota { get; set; }
}
