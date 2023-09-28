using Library.Core.Enums;
using Library.Core.Models;
using Neshan.Domain.DTOs.Common;
using Neshan.Domain.Entities;

namespace Neshan.Domain.Contracts
{
    public interface IRequestRepository
    {
        Task<SharedEnums.SharedResult> Add(ShortUrl url);
    }
}
