using System;
namespace Users.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        //EntityFramework
        protected User() { }
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
            Validate();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator(); //Entidade de validação
            var validation = validator.Validade(this); //Retorno da validação

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors) //Para cada erro identificado na validação 
                    _errors.Add(error.ErrorMessage); //Adiciona na lista de erros

                throw new Exception("Foram encontrados valores inválidos para os campos informados.", _errors);
            }
        }
    }
}