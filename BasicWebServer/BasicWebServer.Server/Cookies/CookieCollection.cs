using BasicWebServer.Server.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Cookies
{
    public class CookieCollection : ICookieCollection
    {
        private Dictionary<string, Cookie> _cookies;
        public CookieCollection()
        {
            _cookies = new Dictionary<string, Cookie>();
        }
        public void Add(string name, string value)
        {

        }

        public bool Contains(string name)
        {
            throw new NotImplementedException();
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
