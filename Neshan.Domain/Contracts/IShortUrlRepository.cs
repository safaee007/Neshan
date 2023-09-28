using Library.Core.Enums;
using Library.Core.Models;
using Neshan.Domain.DTOs.Common;
using Neshan.Domain.Entities;

namespace Neshan.Domain.Contracts
{
    public interface IShortUrlRepository
    {
        Task<(SharedEnums.SharedResult, ResponseModel<IList<ShortUrl>>)> GetURLs(ListFilterDTO filter);
        Task<(SharedEnums.SharedResult, ResponseModel<ShortUrl>)> GetOriginalUrlByKey(string key);
        Task<SharedEnums.SharedResult> Add(ShortUrl url);
        Task<SharedEnums.SharedResult> AddRequest(ShortUrl url);
    }
}
