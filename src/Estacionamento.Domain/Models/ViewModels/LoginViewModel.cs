using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Models.ViewModels;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor informe seu Email")]
    [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de Email válido")]
    public string? Email { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor informe sua Senha")]
    [StringLength(12, MinimumLength = 6, ErrorMessage = "A Senha precisa ter entre 6 e 12 caracteres")]
    public string? Senha { get; set; }
}