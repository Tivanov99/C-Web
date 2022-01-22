using BasicWebServer.Server.Contracts;

namespace BasicWebServer.Server.Session
{
    public class SessionCollection
    {
        private static Dictionary<string, HttpSession> _Sessions = new();

        public static HttpSession GetSession(ICookieCollection cookies)
        {
            string sessionId = cookies.Contains(HttpSession.SessionCookieName)
                ? cookies[HttpSession.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!_Sessions.ContainsKey(sessionId))
            {
                _Sessions[sessionId] = new HttpSession(sessionId);
            }
            return _Sessions[sessionId];
        }
    }
}
