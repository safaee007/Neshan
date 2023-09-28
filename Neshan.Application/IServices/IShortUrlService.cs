using Library.Core.Enums;
using Library.Core.Models;
using Neshan.Domain.DTOs.Common;
using Neshan.Domain.DTOs.ShortURL;
using Neshan.Domain.Entities;

namespace Neshan.Application.IServices
{
    public interface IShortUrlService
    {
        Task<(SharedEnums.SharedResult, ResponseModel<IList<ShortUrlDTO>>)> GetList(ListFilterDTO filter);
        Task<(SharedEnums.SharedResult, ShortUrlDTO)> GetOriginalUrl(string key, Guid userID);
        Task<SharedEnums.SharedResult> AddUrl(ShortUrl url);
        Task<ShortUrl> GenerateShortUrl(Uri url);
    }
}
