using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Domain.Interfaces;

public interface IPessoaUseCases
{
    Task<IEnumerable<Pessoa>> ObterPessoasUseCaseAsync();
    Task<Pessoa?> ObterPessoaUseCaseAsync(string id);
    Task AdicionarPessoaUseCaseAsync(PessoaDTO pessoa);
    Task DeletarPessoaUseCaseAsync(string idPessoa);
    Task AtualizarPessoaUseCaseAsync(Pessoa pessoa);
}