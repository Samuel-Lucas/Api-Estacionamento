using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.DTO;
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
            var pessoas = await _context.Pessoas!
                                        .OrderBy(x => x.Nome.Substring(0, 1).ToUpper())
                                        .ToListAsync();
            return pessoas;
        } catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao buscar pessoas cadastradas: {e.Message}");
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
            throw new Exception($"Ocorreu um erro ao buscar pessoa de id {id}: {e.Message}");
        }
    }

    public async Task<Pessoa?> ObterPessoaPorEmaileSenhaRepositoryAsync(string email, string senha)
    {
        try
        {
            var pessoa = await _context.Pessoas!
                .FirstOrDefaultAsync(x => x.Email == email);
            
            if (pessoa is null)
                return null!;

            if (IsValidUser(senha, pessoa!.Senha))
                return pessoa;
            
            return null!;
        } catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao buscar pessoa de email {email}: {e.Message}");
        }
    }

    public async Task AdicionarPessoaRepositoryAsync(PessoaDTO pessoa)
    {
        try
        {
            var pessoaEntity = new Pessoa
            (
                pessoa.Nome,
                pessoa.SobreNome,
                pessoa.Email,
                HashPassword(pessoa.Senha),
                pessoa.Telefone,
                "User"
            );

            _context.Pessoas!.Add(pessoaEntity);
            await _context.SaveChangesAsync();
        } catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao cadastrar a pessoa: {e.Message}");
        }
    }

    public async Task<bool> IsExistingEmail(string email)
        => await _context.Pessoas.AnyAsync(x => x.Email == email);

    public async Task AtualizarPessoaRepositoryAsync(Pessoa pessoa)
    {
        try
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao buscar pessoa de id {pessoa.IdPessoa}, {e.Message}");
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
            throw new Exception($"Erro ao tentar remover pessoa de id {pessoa.IdPessoa}, {e.Message}");
        }
    }

    private string HashPassword(string senha)
    {
        var hasher = new PasswordHasher<object>();
        return hasher.HashPassword(null!, senha);
    }

    private bool IsValidUser(string senha, string storedHash)
    {
        var hasher = new PasswordHasher<object>();
        var result = hasher.VerifyHashedPassword(null!, storedHash, senha);

        return result == PasswordVerificationResult.Success;
    }
}