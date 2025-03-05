using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Domain.Interfaces;

public interface IPessoaRepository
{
    Task<IEnumerable<Pessoa>> ObterPessoasRepositoryAsync();
    Task<Pessoa?> ObterPessoaRepositoryAsync(string id);
    Task AdicionarPessoaRepositoryAsync(PessoaDTO pessoa);
    Task DeletarPessoaRepositoryAsync(Pessoa pessoa);
    Task AtualizarPessoaRepositoryAsync(Pessoa pessoa);
}