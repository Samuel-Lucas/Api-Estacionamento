using Estacionamento.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Infrastructure.Configurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(k => k.IdPessoa);
        builder.Property(p => p.Nome).HasMaxLength(20).IsRequired();
        builder.Property(p => p.SobreNome).HasMaxLength(20).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(20).IsRequired();
        builder.Property(p => p.Senha).HasMaxLength(32).IsRequired();
        builder.Property(p => p.Telefone).HasMaxLength(12);
        builder.Property(p => p.Role).HasMaxLength(20);
    }
}