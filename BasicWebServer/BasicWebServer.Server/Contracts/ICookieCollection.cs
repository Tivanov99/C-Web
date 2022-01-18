using BasicWebServer.Server.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Contracts
{
    public interface ICookieCollection : IEnumerable<Cookie>
    {
        void Add(string name, string value);

        bool Contains(string name);
    }
}
