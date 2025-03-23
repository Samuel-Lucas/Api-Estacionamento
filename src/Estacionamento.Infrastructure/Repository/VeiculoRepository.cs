using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;
using Estacionamento.Domain.Models.ViewModels;
using Estacionamento.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Infrastructure.Repository;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly AppDbContext _context;

    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VeiculoViewModel>> ObterVeiculosRepositoryAsync()
    {
        try
        {
            var veiculos = await _context.Veiculos!
                                    .Include(p => p.Pessoa)
                                    .ToListAsync();

            var veiculosViewModel = veiculos
                                   .Select(p => new VeiculoViewModel
                                        (
                                            p.IdVeiculo,
                                            p.Marca,
                                            p.Modelo,
                                            p.Cor,
                                            p.Placa,
                                            p.IdPessoa,
                                            p.Pessoa!.Nome,
                                            p.Pessoa.SobreNome
                                        ));
          
            return veiculosViewModel;
        } catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao buscar veiculos cadastrados: {e.Message}");
        }
    }

    public async Task<Veiculo?> ObterVeiculoRepositoryAsync(int idVeiculo)
    {
        try
        {
            var veiculo = await _context.Veiculos!
                                        .Where(v => v.IdVeiculo == idVeiculo)
                                        .Include(p => p.Pessoa)
                                        .FirstOrDefaultAsync();

            return veiculo!;
        } catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao buscar veiculo de id {idVeiculo}: {e.Message}");
        }
    }

    public async Task AdicionarVeiculoRepositoryAsync(Veiculo veiculo)
    {
        try
        {            
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
        } catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao cadastrar o veiculo: {e.Message}");
        }
    }

    public async Task AtualizarVeiculoRepositoryAsync(Veiculo veiculo)
    {
        try
        {
            _context.Entry(veiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        } catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao atualizar veiculo de id {veiculo.IdVeiculo}: {e.Message}");
        }
    }

    public async Task DeletarVeiculoRepositoryAsync(Veiculo veiculo)
    {
        try 
        {
            _context.Veiculos!.Remove(veiculo);
            await _context.SaveChangesAsync();
        } catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao excluir veiculo de id = {veiculo.IdVeiculo}: {e.Message}");
        }
    }
}