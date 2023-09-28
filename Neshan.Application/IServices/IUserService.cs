using Library.Core.Enums;
using Neshan.Domain.DTOs.User;
using Neshan.Domain.Entities;
using System.Reflection;

namespace Neshan.Application.IServices
{
    public interface IUserService
    {
        Task<(SharedEnums.SharedResult, User)> Login(LoginDTO model);
        Task<SharedEnums.SharedResult> Register(UserDTO model);
    }
}
