using Microsoft.AspNetCore.Http;

namespace Neshan.Site.Managers
{
    public static class SessionManager
    {
        private static string _sessionKeyToken = "authToken";
        private static string _sessionKeyUserID = "userID";
        public async static void SetSession(HttpContext context, string token, Guid userID)
        {
            context.Session.SetString(_sessionKeyToken, token);
            context.Session.SetString(_sessionKeyUserID, userID.ToString());
        }

        public async static Task<string> GetUserSession(HttpContext context)
        {
            return context.Session.GetString(_sessionKeyUserID);
        }

        public async static Task<string> GetTokenSession(HttpContext context)
        {
            return context.Session.GetString(_sessionKeyToken);
        }
    }
}
