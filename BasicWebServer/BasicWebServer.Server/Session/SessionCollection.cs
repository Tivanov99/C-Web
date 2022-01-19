using BasicWebServer.Server.Contracts;

namespace BasicWebServer.Server.Session
{
    public class SessionCollection
    {
        private static Dictionary<string, Session> _Sessions = new();

        public static Session GetSession(ICookieCollection cookies)
        {
            string sessionId = cookies.Contains(Session.SessionCookieName)
                ? cookies[Session.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!_Sessions.ContainsKey(sessionId))
            {
                _Sessions[sessionId] = new Session(sessionId);
            }
            return _Sessions[sessionId];
        }
    }
}
