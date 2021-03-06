using FluentValidation;
using Users.Domain.Entities;
namespace Users.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly int NAME_MAX_LENGTH = 150;
        private readonly int EMAIL_MIN_LENGTH = 10;
        private readonly int EMAIL_MAX_LENGTH = 180;
        private readonly int PASSWORD_MIN_LENGTH = 6;
        private readonly int PASSWORD_MAX_LENGTH = 180;

        private readonly string EMAIL_VALIDATOR_REGEX = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public UserValidator()
        {
            //Regras de validação para a entidade
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage($"A entidade {nameof(User)} não pode ser vazia.")

                .NotNull()
                .WithMessage($"A entidade {nameof(User)} não pode ser nula.");

            //Regras de validação dos Campos
            // - Name
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage($"O nome não pode ser vazio.")

                .NotNull()
                .WithMessage($"O nome não pode ser nulo.")

                .MaximumLength(150)
                .WithMessage($"O nome deve ter no máximo {NAME_MAX_LENGTH} caracteres.");

            //MinimunLenght(int: lenght)
            //MaximumLength(int: lenght)

            // - Email
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage($"O e-mail não pode ser vazio.")

                .NotNull()
                .WithMessage($"O e-mail não pode ser nulo.")

                .MinimumLength(EMAIL_MIN_LENGTH)
                .WithMessage($"O e-mail deve ter no mínimo {EMAIL_MIN_LENGTH} caracteres.")

                .MaximumLength(EMAIL_MAX_LENGTH)
                .WithMessage($"O e-mail deve ter no máximo {EMAIL_MAX_LENGTH} caracteres.")

                .Matches(EMAIL_VALIDATOR_REGEX)
                .WithMessage($"E-mail inválido.");

            //Password

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage($"A senha não pode ser vazia.")

                .NotNull()
                .WithMessage($"O nome não pode ser nula.")

                .MinimumLength(PASSWORD_MIN_LENGTH)
                .WithMessage($"A senha deve ter no mínimo {EMAIL_MIN_LENGTH} caracteres.")

                .MaximumLength(PASSWORD_MAX_LENGTH)
                .WithMessage($"A senha deve ter no máximo {EMAIL_MAX_LENGTH} carateres.");
        }
    }
}