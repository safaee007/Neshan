using Library.Core.Enums;
using Library.Core.Models;
using Neshan.Domain.Contracts;
using Neshan.Domain.DTOs.Common;
using Neshan.Domain.Entities;
using Neshan.Infrastructure.DatabaseContext;
using Neshan.Infrastructure.Managers;

namespace Neshan.Infrastructure.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly SqlContext _db;
        public RequestRepository(SqlContext db)
        {
            _db = db;
        }

        public async Task<SharedEnums.SharedResult> Add(ShortUrl url)
        {
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;

            try
            {
                DateTime date = DateTime.UtcNow;
                RequestUrl request = new RequestUrl()
                {
                    ShortUrlID = url.ID,
                    UserID = url.UserID,
                    CreateDate = date,
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
    }
}
