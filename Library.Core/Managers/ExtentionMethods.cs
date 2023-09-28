using System.Globalization;

namespace Library.Core.Managers
{
    public static class ExtentionMethods
    {
        public static long ToUnixtime(this DateTime date)
        {
            return (long)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime ToDatetime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1);
            dtDateTime = dtDateTime.AddSeconds(unixtime);

            return dtDateTime;
        }
        
        public static string ConvertDate(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
        }
    }
}
