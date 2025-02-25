using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Domain.Interfaces;

public interface IPessoaRepository
{
    Task<IEnumerable<Pessoa>> ObterPessoasRepositoryAsync();
    Task<Pessoa?> ObterPessoaRepositoryAsync(string id);
    Task<Pessoa> AdicionarPessoaRepositoryAsync(Pessoa pessoa);
    Task DeletarPessoaRepositoryAsync(Pessoa pessoa);
    Task AtualizarPessoaRepositoryAsync(Pessoa pessoa);
}