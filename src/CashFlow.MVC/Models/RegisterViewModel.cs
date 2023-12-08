using System.ComponentModel.DataAnnotations;

namespace CashFlow.MVC.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O campo de e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo de senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
