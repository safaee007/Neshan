using Library.Core.Enums;
using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using Neshan.Domain.Contracts;
using Neshan.Domain.DTOs.Common;
using Neshan.Domain.Entities;
using Neshan.Infrastructure.DatabaseContext;
using Neshan.Infrastructure.Managers;

namespace Neshan.Infrastructure.Repository
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly SqlContext _db;
        public ShortUrlRepository(SqlContext db)
        {
            _db = db;
        }

        public async Task<(SharedEnums.SharedResult, ResponseModel<IList<ShortUrl>>)> GetURLs(ListFilterDTO filterModel)
        {
            ResponseModel<IList<ShortUrl>> retval = new ResponseModel<IList<ShortUrl>>();
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;

            try
            {
                IQueryable<ShortUrl> query = _db.ShortURLs.Where(x =>
                                            (!string.IsNullOrEmpty(filterModel.Search) ? x.OriginalURL.Host.Contains(filterModel.Search) : 1 == 1) &&
                                            (filterModel.userID != Guid.Empty ? x.UserID == filterModel.userID : 1 == 1)
                );

                //sort
                query = query.ToSort(filterModel.Sort);

                //execute
                retval.Count = query.Count();
                retval.Items = query
                    .Skip(filterModel.From)
                    .Take(filterModel.Count)
                    .Select(s => new ShortUrl
                    {
                        OriginalURL = s.OriginalURL,
                        UrlKey = s.UrlKey,
                        ShortURL = s.ShortURL,
                        UserID = s.UserID,
                        LastVisit = s.LastVisit,
                        CreateDate = s.CreateDate,
                    })
                    .ToList();

                status = SharedEnums.SharedResult.Successful;
            }
            catch (Exception ex)
            {
                status = SharedEnums.SharedResult.UnSuccessful;
                //add system log
            }

            return (status, retval);
        }

        public async Task<(SharedEnums.SharedResult, ResponseModel<ShortUrl>)> GetOriginalUrlByKey(string key)
        {
            ResponseModel<ShortUrl> retval = new ResponseModel<ShortUrl>();
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;

            try
            {
                ShortUrl item = _db.ShortURLs.FirstOrDefault(x => x.UrlKey == key);
                if (item != null)
                {
                    if (item.LastVisit < DateTime.UtcNow.AddYears(-1))
                    {
                        status = SharedEnums.SharedResult.Expired;
                        _db.ShortURLs.Remove(item);
                        
                        //1- can true flag isRemoved
                        //2- can backup another db
                    }
                    else
                    {
                        item.RequestUrls = _db.RequestUrls.Where(r=> r.ShortUrlID == item.ID).ToList();
                        item.LastVisit = DateTime.UtcNow;
                        retval.Items = item;
                        status = SharedEnums.SharedResult.Successful;
                    }
                    _db.SaveChanges();
                }
                else
                {
                    status = SharedEnums.SharedResult.NotFound;
                }

            }
            catch (Exception ex)
            {
                status = SharedEnums.SharedResult.UnSuccessful;
                //add system log
            }

            return (status, retval);
        }

        public async Task<SharedEnums.SharedResult> Add(ShortUrl url)
        {
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;
            int limitUrl = 10; //can read from config

            try
            {
                //validates limited
                int count = _db.ShortURLs.Count(r => r.UserID == url.UserID);
                if (count <= limitUrl)
                {
                    //validates duplicate url
                    bool existCount = _db.ShortURLs.Any(r => r.OriginalURL == url.OriginalURL);
                    if (!existCount)
                    {
                        url.CreateDate = DateTime.UtcNow;
                        url.LastVisit = url.CreateDate;
                        _db.Add(url);
                        _db.SaveChanges();
                        status = SharedEnums.SharedResult.Successful;
                    }
                    else
                    {
                        status = SharedEnums.SharedResult.Exist;
                    }
                }
                else
                {
                    status = SharedEnums.SharedResult.LimitUrl;
                }
            }
            catch (Exception ex)
            {
                status = SharedEnums.SharedResult.UnSuccessful;
                //add system log
            }

            return status;
        }

        public async Task<SharedEnums.SharedResult> AddRequest(ShortUrl shortUrl)
        {
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;

            try
            {
                RequestUrl request = new RequestUrl()
                {
                    ShortUrlID = shortUrl.ID,
                    UserID = shortUrl.UserID,
                    CreateDate = DateTime.UtcNow,
                };
                _db.RequestUrls.Add(request);
                _db.SaveChanges();
                status = SharedEnums.SharedResult.Successful;
            }
            catch (Exception ex)
            {
                status = SharedEnums.SharedResult.UnSuccessful;
                //add system log
            }

            return status;
        }

        public async Task<(SharedEnums.SharedResult, ResponseModel<ShortUrl>)> GetOriginalURL(string key)
        {
            ResponseModel<ShortUrl> retval = new ResponseModel<ShortUrl>();
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;

            try
            {
                ShortUrl item = _db.ShortURLs.FirstOrDefault(x => x.UrlKey == key);
                if (item != null)
                {
                    if (item.LastVisit < DateTime.UtcNow.AddYears(-1))
                    {
                        status = SharedEnums.SharedResult.Expired;
                        _db.ShortURLs.Remove(item);

                        //1- can true flag isRemoved
                        //2- can backup another db
                    }
                    else
                    {
                        item.RequestUrls = _db.RequestUrls.Where(r => r.ShortUrlID == item.ID).ToList();
                        item.LastVisit = DateTime.UtcNow;
                        retval.Items = item;
                        status = SharedEnums.SharedResult.Successful;
                    }
                    _db.SaveChanges();
                }
                else
                {
                    status = SharedEnums.SharedResult.NotFound;
                }

            }
            catch (Exception ex)
            {
                status = SharedEnums.SharedResult.UnSuccessful;
                //add system log
            }

            return (status, retval);
        }
    }
}
