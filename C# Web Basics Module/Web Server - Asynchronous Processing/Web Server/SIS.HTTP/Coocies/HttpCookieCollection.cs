using SIS.HTTP.Coocies.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Coocies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
       Dictionary<string, HttpCookie> cookies;
        public HttpCookieCollection()
        {
            cookies = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie cookie)
        {
            cookies.Add(cookie.Value, cookie);
        }

        public bool ContaisCookie(string key)
        {
            return cookies.Where(c => c.Key == key).Any();
        }

        public HttpCookie GetCookie(string key)
        {
            return cookies.Where(c => c.Key == key).FirstOrDefault().Value;
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool HasCookies()
        {
            return cookies.Any();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (HttpCookie cookie in cookies.Values)
            {
                yield return cookie;
            }
        }
        public override string ToString()
        {
            //check for default cookie separator
            return String.Join("; ", cookies.Values);
        }
    }
}
