using Library.Core.Managers;
using Neshan.Domain.DTOs.ShortURL;
using Neshan.Domain.Entities;

namespace Neshan.Application.Managers
{
    public static class MapperExtentions
    {
        public static ShortUrlDTO ToShortUrlDTO(this ShortUrl model)
        {
            ShortUrlDTO retVal = new ShortUrlDTO();

            if (model != null)
            {
                retVal.ShortUrlID = model.ID;
                retVal.OriginalURL = model.OriginalURL;
                retVal.ShortURL = model.ShortURL;
                retVal.UrlKey = model.UrlKey;
                retVal.ShortURL = model.ShortURL;
                retVal.UserID = model.UserID;
                retVal.VisitCount = model.RequestUrls?.Count ?? 0;
                retVal.CreateDate = model.CreateDate.ToUnixtime();
                retVal.CreateDate2 = model.CreateDate.ConvertDate();
            }

            return retVal;
        }
        public static IList<ShortUrlDTO> ToShortUrlDTO_List(this IList<ShortUrl> model)
        {
            IList<ShortUrlDTO> retVal = new List<ShortUrlDTO>();

            if (model != null)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    retVal.Add(model[i].ToShortUrlDTO());
                }
            }

            return retVal;
        }
    }
}
