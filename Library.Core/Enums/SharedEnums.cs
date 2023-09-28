using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Enums
{
    public class SharedEnums
    {
        public enum SharedResult
        {
            None = 0,
            Successful = 1,
            UnSuccessful = 2,
            NotEmpty = 3,
            NotValidAutorizeCode = 4,
            NotValidRequest = 5,
            AccessDeny = 6,
            NotFound = 7,
            Expired = 8,
            Exist = 9,
            Duplicate = 10,

            //user
            NotValidPassOrMail = 20,
            NotValidCode = 21,
            UserNotFound = 22,
            UserExist = 23,
            NotValidPhone = 24,
            UserLocked = 25,
            UserDisabled = 26,
            InvalidPassword = 27,
            
            //short url
            LimitUrl = 28,
        }

        public enum Entities
        {
            None = 0,

            User = 1,
            Link = 2
        }
        
        public enum Languages
        {
            None = 0,

            Farsi = 1,
            English = 2,
            Arabic = 3
        }

        public enum BaseStatus
        {
            None = 0,

            NonActice = 1,
            RequestActive = 2,
            Reject = 3,
            Active = 4,
        }

        public enum Sort
        {
            ID = 1,
            ID_desc = 2,
            CreateDate = 3,
            CreateDate_desc = 4,
            ModifyDate = 5,
            ModifyDate_desc = 6,
        }
    }
}
