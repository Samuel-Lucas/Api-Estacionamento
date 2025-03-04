using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;
using Estacionamento.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Infrastructure.Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pessoa>> ObterPessoasRepositoryAsync()
    {
        try
        {
            var pessoas = await _context.Pessoas!.ToListAsync();
            return pessoas;
        } catch (Exception e)
        {
            throw new Exception($"Ocorre um erro ao buscar pessoas cadastradas: {e.Message}");
        }
    }

    public async Task<Pessoa?> ObterPessoaRepositoryAsync(string id)
    {
        try
        {
            var pessoa = await _context.Pessoas!.FirstOrDefaultAsync(s => s.IdPessoa == id);
            return pessoa!;
        } catch (Exception e)
        {
            throw new Exception($"Ocorre um erro ao buscar pessoa de id {id}: {e.Message}");
        }
    }

    public async Task<Pessoa> AdicionarPessoaRepositoryAsync(Pessoa pessoa)
    {
        try
        {
            pessoa.IdPessoa = Guid.NewGuid().ToString();
            pessoa.Role = "User";
            pessoa.Senha = HashPassword(pessoa.Senha);
            
            await _context.Pessoas!.AddAsync(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        } catch (Exception e)
        {
            throw new Exception($"Ocorre um erro ao cadastrar a pessoa: {e.Message}");
        }
    }

    public async Task AtualizarPessoaRepositoryAsync(Pessoa pessoa)
    {
        try
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            _context.Entry(pessoa).Property(x => x.Senha).IsModified = false;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Ocorre um erro ao buscar pessoa de id {pessoa.IdPessoa}, {e.Message}");
        }
    }

    public async Task DeletarPessoaRepositoryAsync(Pessoa pessoa)
    {
        try
        {
            _context.Pessoas!.Remove(pessoa);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao tentar remover pessoade id {pessoa.IdPessoa}, {e.Message}");
        }
    }

    private string HashPassword(string senha)
    {
        var hasher = new PasswordHasher<object>();
        return hasher.HashPassword(null!, senha);
    }
}