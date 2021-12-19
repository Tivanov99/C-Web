using System.Collections.Generic;

namespace SIS.HTTP.Coocies.Contracts
{
    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void AddCookie(HttpCookie cookie);

        bool ContaisCookie(string key);

        HttpCookie GetCookie(string key);

        bool HasCookies();
    }
}
