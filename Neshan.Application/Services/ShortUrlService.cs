using Library.Core.Enums;
using Library.Core.Models;
using Neshan.Application.IServices;
using Neshan.Application.Logics;
using Neshan.Application.Managers;
using Neshan.Domain.Contracts;
using Neshan.Domain.DTOs.Common;
using Neshan.Domain.DTOs.ShortURL;
using Neshan.Domain.Entities;

namespace Neshan.Application.Services
{
    public class ShortUrlService : IShortUrlService
    {
        private readonly IShortUrlRepository _shortUrlRepository;
        public ShortUrlService(IShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }

        public async Task<(SharedEnums.SharedResult, ResponseModel<IList<ShortUrlDTO>>)> GetList(ListFilterDTO filter)
        {
            ResponseModel<IList<ShortUrlDTO>> retval = new ResponseModel<IList<ShortUrlDTO>>();
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;

            var result = await _shortUrlRepository.GetURLs(filter);
            status = result.Item1;
            
            retval.Items = result.Item2.Items.ToShortUrlDTO_List();
            retval.Count = result.Item2.Count;

            return (status, retval);
        }

        public async Task<(SharedEnums.SharedResult, ShortUrlDTO)> GetOriginalUrl(string key, Guid userID)
        {
            ShortUrlDTO retval = new ShortUrlDTO();
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;

            var result = await _shortUrlRepository.GetOriginalUrlByKey(key);
            status = result.Item1;
            retval = result.Item2.Items.ToShortUrlDTO();

            //add visit count
            if (result.Item1 == SharedEnums.SharedResult.Successful)
            {
                _shortUrlRepository.AddRequest(result.Item2.Items);
            }

            return (status, retval);
        }

        public async Task<ShortUrl> GenerateShortUrl(Uri url)
        {
            ShortUrl retval = new ShortUrl();

            retval.OriginalURL = url;
            retval.UrlKey = GenerateShortUrlKey.Generate();
            retval.ShortURL = new Uri("http://localhost:43587");

            return retval;
        }

        public async Task<SharedEnums.SharedResult> AddUrl(ShortUrl url)
        {
            SharedEnums.SharedResult retval = SharedEnums.SharedResult.None;

            retval = await _shortUrlRepository.Add(url);

            return retval;
        }
    }
}
