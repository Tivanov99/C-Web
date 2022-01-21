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
        => this._cookies[name] = new Cookie(name, value);

        public bool Contains(string name)
            => this._cookies.ContainsKey(name);

        public IEnumerator<Cookie> GetEnumerator()
            => this._cookies
            .Values
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
