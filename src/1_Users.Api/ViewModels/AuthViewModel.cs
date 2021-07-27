using System.ComponentModel.DataAnnotations;

namespace Users.Api.ViewModels
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "O Login não pode ser vazio.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia.")]
        public string Password { get; set; }
    }
}