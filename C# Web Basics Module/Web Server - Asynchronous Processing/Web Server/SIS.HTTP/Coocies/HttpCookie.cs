using SIS.HTTP.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Coocies
{
    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;
        private const string HttpCookieDefaultPath = "/";

        public HttpCookie(string key, string value
            , int expired = HttpCookieDefaultExpirationDays
            , string path = HttpCookieDefaultPath)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));
            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Path = path;
            this.Expires = DateTime.UtcNow.AddDays(expired);
        }

        public HttpCookie(string key, string value, bool isNew
            , int expired = HttpCookieDefaultExpirationDays
            , string path = HttpCookieDefaultPath)
            : this(key, value, expired, path)
        {
            this.IsNew = isNew;
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; private set; }

        public string Path { get; set; }

        public bool IsNew { get; }

        public bool HttpOnly { get; set; } = true;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Key}={this.Value}; Expired={this.Expires:R}");

            if (this.HttpOnly)
            {
                sb.Append("; HttpOnly");
            }
            sb.Append($"; Path={this.Path}");

            return sb.ToString();
        }

        public void Delete()
        {
            this.Expires = DateTime.UtcNow.AddDays(-1);
        }

    }
}
