namespace Estacionamento.Domain.Models.DTO;

public class PessoaUpdateDTO
{
    public string IdPessoa { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string SobreNome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telefone { get; set; } = null!;
}