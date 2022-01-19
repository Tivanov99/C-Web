namespace BasicWebServer.Server.Cookies
{
    using BasicWebServer.Server.Contracts;
    using System.Collections;
    using System.Collections.Generic;

    public class CookieCollection : ICookieCollection
    {
        private Dictionary<string, Cookie> _cookies;
        public CookieCollection()
        {
            _cookies = new Dictionary<string, Cookie>();
        }

        public string this[string name]
            => this._cookies[name].Value;

        public void Add(string name, string value)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
            {
                this._cookies.Add(name, new Cookie(name, value));
            }
        }

        public bool Contains(string name)
        {
            return this._cookies.ContainsKey(name);
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            foreach (Cookie item in _cookies.Values)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
