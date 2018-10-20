﻿using Core.Models;
using Core.Ports.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Validations
{
    internal sealed class CreateUserValidator : AbstractValidator<User>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(request => request.Email).EmailAddress().WithMessage("Correo electronico invalido");
            RuleFor(request => request.Email).Must(NotExistEmail).WithMessage("El correo electronico esta actualmente en uso");
            RuleFor(request => request.Password.Length).GreaterThan(5).WithMessage("Contraseña invalida");
        }

        private bool NotExistEmail(string email) 
            => !_userRepository.Exists(user => user.Email == email);

        /// <inheritdoc />
        public override ValidationResult Validate(ValidationContext<User> context)
            => context.InstanceToValidate == null ? BuildValidationResult() : base.Validate(context);


        private ValidationResult BuildValidationResult()
            => new ValidationResult(new[]
                { new ValidationFailure("User", "InvalidCreateUserInstance") });
    }
}