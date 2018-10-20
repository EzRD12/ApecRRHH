﻿using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;
using Core.Validations;
using System;
using System.Linq;
using FluentValidationsResult = FluentValidation.Results.ValidationResult;


namespace Core.Managers
{
    public sealed class UserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository) 
            => _userRepository = userRepository;

        public IOperationResult<User> Create(User user)
        {
            user.CurrentRole = Role.CandidateEmployee;
            CreateUserValidator validator = new CreateUserValidator(_userRepository);
            FluentValidationsResult validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                string errors = string.Join(",", validationResult.Errors.Select(errorsFound => errorsFound.ErrorMessage)); 
                return BasicOperationResult<User>.Fail(errors);
            }

            return _userRepository.Create(user);
        }

        public IOperationResult<User> Authenticate(AuthenticateUserRequest request)
        {
            User userFound = _userRepository.Find(user => user.Email == request.Email && user.Password == request.Password);

            if (userFound == null)
            {
                return BasicOperationResult<User>.Fail("InvalidCredentials");
            }

            return BasicOperationResult<User>.Ok(userFound);
        }

        public IOperationResult<User> Find(Guid userId)
        {
            User userFound = _userRepository.Find(user => user.Id == userId, user => user.Preparations,
                                                                             user => user.Competences,
                                                                             user => user.Languages, 
                                                                             user => user.WorkExperiences);
            return userFound == null ? BasicOperationResult<User>.Fail("UserNotFound") : BasicOperationResult<User>.Ok(userFound);
        }

        public IOperationResult<User> Update(User user)
        {
            bool userExists = _userRepository.Exists(us => us.Id == user.Id);

            return !userExists 
                ? BasicOperationResult<User>.Fail("UserDoesNotExistsOnRepository") 
                : _userRepository.Update(user);
        }

        public IOperationResult<bool> ChangeUserRole(Guid userId, Role role)
        {
            User userFound = _userRepository.Find(user => user.Id == userId);

            if (userFound == null)
            {
                return BasicOperationResult<bool>.Fail("UserNotFound");
            }

            userFound.CurrentRole = role;

            IOperationResult<User> operationResult = _userRepository.Update(userFound);

            return operationResult.Success
                ? BasicOperationResult<bool>.Ok()
                : BasicOperationResult<bool>.Fail("OperationFailed");
        }
    }
}
