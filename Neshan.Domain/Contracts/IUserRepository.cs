using Library.Core.Enums;
using Neshan.Domain.Entities;

namespace Neshan.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<(SharedEnums.SharedResult, User)> Login(User model);
        Task<SharedEnums.SharedResult> Register(User model);
    }
}
