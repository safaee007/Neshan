using Library.Core.Enums;
using Neshan.Domain.Contracts;
using Neshan.Domain.Entities;
using Neshan.Infrastructure.DatabaseContext;
using Neshan.Infrastructure.Managers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Neshan.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext _db;
        public UserRepository(SqlContext db)
        {
            _db = db;
        }

        public async Task<(SharedEnums.SharedResult, User)> Login(User model)
        {
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;
            User retval = null;

            try
            {
                User item = _db.Users.FirstOrDefault(r => r.Email == model.Email);
                if (item != null)
                {
                    if (item.Password == SecurityManager.encryptPassword(model.Password))
                    {
                        if (!item.IsDisabled)
                        {
                            if (item.FailedLoginCount < 6 || item.FailedLoginDate < DateTime.UtcNow.AddMinutes(-30))
                            {
                                item.FailedLoginCount = 0;
                                _db.SaveChanges();
                                
                                retval = item;
                                status = SharedEnums.SharedResult.Successful;
                            }
                            else
                            {
                                //user locked
                                status = SharedEnums.SharedResult.UserLocked;
                            }
                        }
                        else
                        {
                            //disables
                            status = SharedEnums.SharedResult.UserDisabled;
                        }
                    }
                    else
                    {
                        //invalid pass
                        byte failedLoginCount = 0;
                        if (item.FailedLoginDate > DateTime.UtcNow.AddMinutes(-30))
                        {
                            failedLoginCount = (byte)(item.FailedLoginCount + 1);
                        }
                        else
                        {
                            failedLoginCount = 1;
                        }

                        item.FailedLoginCount = failedLoginCount;
                        item.FailedLoginDate = DateTime.UtcNow;
                        _db.SaveChanges();
                        status = SharedEnums.SharedResult.NotValidPassOrMail;
                    }
                }
                else
                {
                    status = SharedEnums.SharedResult.UserNotFound;
                }
            }
            catch (Exception ex)
            {
                status = SharedEnums.SharedResult.UnSuccessful;
                //add system log
            }

            return (status, retval);
        }

        public async Task<SharedEnums.SharedResult> Register(User model)
        {
            SharedEnums.SharedResult status = SharedEnums.SharedResult.None;

            try
            {
                //check exist
                int count = _db.Users.Count(r=> r.Email.ToLower() == model.Email.ToLower());
                if (count == 0)
                {
                    //add new
                    model.UserID = Guid.NewGuid();
                    model.Password = SecurityManager.encryptPassword(model.Password);

                    _db.Add(model);
                    _db.SaveChanges();

                    status = SharedEnums.SharedResult.Successful;
                }
                else
                {
                    status = SharedEnums.SharedResult.UserExist;
                }
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
