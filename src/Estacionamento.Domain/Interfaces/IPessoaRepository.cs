using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Domain.Interfaces;

public interface IPessoaRepository
{
    Task<IEnumerable<Pessoa>> ObterPessoasRepositoryAsync();
    Task<Pessoa?> ObterPessoaRepositoryAsync(string id);
    Task<Pessoa> AdicionarPessoaRepositoryAsync(Pessoa pessoa);
    Task DeletarPessoaRepositoryAsync(string idPessoa);
    Task AtualizarPessoaRepositoryAsync(Pessoa pessoa);
}