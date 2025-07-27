using Estacionamento.Domain.Models.Entities;
using Estacionamento.Domain.Models.ViewModels;

namespace Estacionamento.Domain.Interfaces;

public interface IVeiculoRepository
{
    Task<IEnumerable<VeiculoViewModel>> ObterVeiculosRepositoryAsync();
    Task<Veiculo?> ObterVeiculoRepositoryAsync(int idVeiculo);
    Task<bool> VerificaPessoaComVeiculoRepositoryAsync(string idPessoa);
    Task<int> ObterQuantidadeVeiculosRepositoryAsync();
    Task AdicionarVeiculoRepositoryAsync(Veiculo veiculo);
    Task DeletarVeiculoRepositoryAsync(Veiculo veiculo);
    Task AtualizarVeiculoRepositoryAsync(Veiculo veiculo);
}