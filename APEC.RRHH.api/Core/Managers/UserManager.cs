using System;
using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;

namespace Core.Managers
{
    public sealed class UserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IOperationResult<User> Create(User user) 
            => _userRepository.Create(user);

        public IOperationResult<User> Authenticate(AuthenticateUserRequest request)
        {
            User userFound = _userRepository.Find(user => user.Email == request.Email && user.Password == request.Password);
            return userFound == null ? BasicOperationResult<User>.Fail("InvalidCredentials") : BasicOperationResult<User>.Ok(userFound);
        }

        public IOperationResult<User> Find(Guid userId)
        {
            User userFound = _userRepository.Find(user => user.Id == userId);
            return userFound == null ? BasicOperationResult<User>.Fail("UserNotFound") : BasicOperationResult<User>.Ok(userFound);
        }

        public IOperationResult<User> Update(User user)
        {
            return _userRepository.Update(user);
        }

        public IOperationResult<bool> ChangeUserState(Guid userId, FeatureStatus status)
        {
            User userFound = _userRepository.Find(user => user.Id == userId);

            if (userFound == null)
            {
                return BasicOperationResult<bool>.Fail("UserNotFound");
            }

            userFound.Status = status;

            IOperationResult<User> operationResult = _userRepository.Update(userFound);

            return operationResult.Success
                ? BasicOperationResult<bool>.Ok()
                : BasicOperationResult<bool>.Fail("OperationFailed");
        }
    }
}
