using System.ComponentModel.DataAnnotations;

namespace Users.Api.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail não pode ser vazio")]
        [MinLength(10, ErrorMessage = "O e-mail deve ter no mínimo 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O e-mail deve ter no máximo 180 caracteres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [MaxLength(180, ErrorMessage = "A senha deve ter no máximo 180 caracteres.")]
        public string Password { get; set; }
    }
}