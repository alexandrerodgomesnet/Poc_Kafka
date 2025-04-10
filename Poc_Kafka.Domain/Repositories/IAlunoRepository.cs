using Poc_Kafka.Domain.Entities;

namespace Poc_Kafka.Domain.Repositories
{
    public interface IAlunoRepository
    {
        Task<Aluno> CreateAsync(Aluno sale, CancellationToken cancellationToken = default);
        Task<Aluno> UpdateAsync(Aluno sale, CancellationToken cancellationToken = default);
        Task<Aluno?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
