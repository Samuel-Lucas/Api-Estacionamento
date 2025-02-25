using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;
using Estacionamento.Domain.Models.ViewModels;

namespace Estacionamento.Application.UseCases;

public class VeiculoUseCases : IVeiculoUseCases
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoUseCases(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<IEnumerable<VeiculoViewModel>> ObterVeiculosUseCaseAsync()
    {
        var veiculos = await _veiculoRepository.ObterVeiculosRepositoryAsync();

        var veiculosResponse = veiculos
                                   .Select(p => new VeiculoViewModel
                                        (
                                            p.idVeiculo,
                                            p.marca,
                                            p.modelo,
                                            p.cor,
                                            p.placa,
                                            p.IdPessoa,
                                            p.nome,
                                            p.sobreNome
                                        ));
          
        return veiculosResponse;
    }

    public async Task<Veiculo?> ObterVeiculoUseCaseAsync(int idVeiculo)
        => await _veiculoRepository.ObterVeiculoRepositoryAsync(idVeiculo);

    public async Task<Veiculo> AdicionarVeiculoUseCaseAsync(Veiculo veiculo)
    {
        return await _veiculoRepository.AdicionarVeiculoRepositoryAsync(veiculo);
    }

    public async Task AtualizarVeiculoUseCaseAsync(Veiculo veiculo)
    {
        var consultaVeiculo = ObterVeiculoUseCaseAsync(veiculo.IdVeiculo).Result;
        if (consultaVeiculo is null) return;

        await _veiculoRepository.AtualizarVeiculoRepositoryAsync(veiculo);
    }

    public async Task DeletarVeiculoUseCaseAsync(int idVeiculo)
    {
        var resultadoVeiculo = ObterVeiculoUseCaseAsync(idVeiculo).Result;
        if (resultadoVeiculo is null) return;
        await _veiculoRepository.DeletarVeiculoRepositoryAsync(resultadoVeiculo);
    }
}