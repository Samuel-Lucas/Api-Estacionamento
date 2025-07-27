using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.Entities;
using Estacionamento.Domain.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace Estacionamento.Application.UseCases;

public class VeiculoUseCases : IVeiculoUseCases
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly ILogger<VeiculoUseCases> _logger;

    public VeiculoUseCases(IVeiculoRepository veiculoRepository, ILogger<VeiculoUseCases> logger)
    {
        _veiculoRepository = veiculoRepository;
        _logger = logger;
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

    public async Task<VeiculoViewModel?> ObterVeiculoUseCaseAsync(int idVeiculo)
    {
        var veiculo = await _veiculoRepository.ObterVeiculoRepositoryAsync(idVeiculo);
        return new VeiculoViewModel
                    (
                        veiculo!.IdVeiculo,
                        veiculo.Marca,
                        veiculo.Modelo,
                        veiculo.Cor,
                        veiculo.Placa,
                        veiculo.IdPessoa,
                        veiculo.Pessoa!.Nome,
                        veiculo.Pessoa.SobreNome
                    );
    }

    public async Task<int> ObterQuantidadeVeiculosCadastradosUseCaseAsync()
        => await _veiculoRepository.ObterQuantidadeVeiculosRepositoryAsync();


    public async Task<bool> AdicionarVeiculoUseCaseAsync(VeiculoInsertDTO veiculoDto)
    {
        if (await _veiculoRepository.VerificaPessoaComVeiculoRepositoryAsync(veiculoDto.IdPessoa))
        {
            _logger.LogInformation("Usuário já tem um veículo cadastrado");
            return false;
        }

        var veiculo = new Veiculo
        (
            veiculoDto.Marca,
            veiculoDto.Modelo,
            veiculoDto.Cor,
            veiculoDto.Placa,
            veiculoDto.IdPessoa
        );

        await _veiculoRepository.AdicionarVeiculoRepositoryAsync(veiculo);
        return true;
    }

    public async Task AtualizarVeiculoUseCaseAsync(VeiculoUpdateDTO veiculoAtualizado)
    {
        var veiculo = await _veiculoRepository.ObterVeiculoRepositoryAsync(veiculoAtualizado.IdVeiculo);
        if (veiculo is null) return;

        // A Refatorar
        veiculo.Marca = veiculoAtualizado.Marca;
        veiculo.Modelo = veiculoAtualizado.Modelo;
        veiculo.Cor = veiculoAtualizado.Cor;
        veiculo.Placa = veiculoAtualizado.Placa;

        await _veiculoRepository.AtualizarVeiculoRepositoryAsync(veiculo);
    }

    public async Task DeletarVeiculoUseCaseAsync(int idVeiculo)
    {
        var resultadoVeiculo = await _veiculoRepository.ObterVeiculoRepositoryAsync(idVeiculo);
        if (resultadoVeiculo is null) return;
        await _veiculoRepository.DeletarVeiculoRepositoryAsync(resultadoVeiculo);
    }
}