﻿namespace BasicWebServer.Server.Headers
{
    using BasicWebServer.Server.Headers.Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HeaderCollection : IHeaderCollection
    {
        private readonly Dictionary<string, IHeader> _headers;

        public HeaderCollection()
        {
            this._headers = new Dictionary<string, IHeader>();
        }

        public string this[string name]
         => this._headers[name].Value;

        public int Count => this._headers.Count();

        public void Add(string name, string value)
            => this._headers[name] = new Header(name, value);

        public bool ContaisHeader(string name)
            => this._headers.ContainsKey(name);

        public IEnumerator<IHeader> GetEnumerator()
            => this._headers
            .Values
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
