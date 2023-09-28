using Library.Core.Enums;
using Neshan.Application.IServices;
using Neshan.Domain.Contracts;
using Neshan.Domain.DTOs.User;
using Neshan.Domain.Entities;

namespace Neshan.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(SharedEnums.SharedResult, User)> Login(LoginDTO model)
        {
            User user = new User();

            //map // can user automapper 
            user.Email = model.Username;
            user.Password = model.Password;
            var result = await _userRepository.Login(user);

            return result;
        }

        public async Task<SharedEnums.SharedResult> Register(UserDTO model)
        {
            User user = new User();

            //map // can user automapper 
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Password = model.Password;
            var result = await _userRepository.Register(user);

            return result;
        }
    }
}
