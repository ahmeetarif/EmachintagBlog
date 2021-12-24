using System;

namespace EmachintagBlog.Client.WebApp.Common.Extensions
{
    public static class DateTimeExt
    {
        public static string TimeAgo(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now.Subtract(dateTime);

            string result;
            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("yaklaşık {0} saniye önce", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("yaklaşık {0} dakika önce", timeSpan.Minutes) :
                    "yaklaşık 1 dakika önce";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("yaklaşık {0} saat önce", timeSpan.Hours) :
                    "yaklaşık 1 saat önce";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("yaklaşık {0} gün önce", timeSpan.Days) :
                    "dün";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("yaklaşık {0} ay önce", timeSpan.Days / 30) :
                    "yaklaşık 1 ay önce";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("yaklaşık {0} yıl önce", timeSpan.Days / 365) :
                    "yaklaşık 1 yıl önce";
            }

            return result;
        }
    }
}