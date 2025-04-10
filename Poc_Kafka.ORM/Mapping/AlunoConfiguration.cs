using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc_Kafka.Domain.Entities;

namespace Poc_Kafka.ORM.Mapping
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Disciplina)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Nota)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
