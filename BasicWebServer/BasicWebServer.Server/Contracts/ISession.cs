using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Contracts
{
    public interface ISession
    {
        public string Key { get; }

        public string Id { get; }

        public string this[string key] { get; set; }

        bool ContainsKey(string key);

        public void Clear();
    }
}
