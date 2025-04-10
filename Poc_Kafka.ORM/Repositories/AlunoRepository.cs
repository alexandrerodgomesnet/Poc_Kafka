using Microsoft.EntityFrameworkCore;
using Poc_Kafka.Domain.Entities;
using Poc_Kafka.Domain.Repositories;

namespace Poc_Kafka.ORM.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly DefaultContext _context;
    public AlunoRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Aluno> CreateAsync(Aluno aluno, CancellationToken cancellationToken = default)
    {
        await _context.Alunos.AddAsync(aluno, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return aluno;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var aluno = await GetByIdAsync(id, cancellationToken);
        if (aluno == null)
            return false;

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Aluno?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => 
        await _context.Alunos
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

    public async Task<Aluno> UpdateAsync(Aluno aluno, CancellationToken cancellationToken = default)
    {
        _context.Alunos.Attach(aluno);
        await _context.SaveChangesAsync(cancellationToken);
        return aluno;
    }
}
