using SIS.HTTP.Session.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.Session
{
    public class HttpSession : IHttpSession
    {
        private Dictionary<string, Object> objects;

        public HttpSession(string id)
        {
            this.Id = id;
            objects = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            this.objects.Add(name, parameter);
        }

        public void ClearParameters()
        {
            objects.Clear();
        }

        public bool ContainsParameter(string name)
        {
            return this.objects.Keys.Where(ob => nameof(ob) == name).Any();
        }

        public object GetParameter(string name)
        {
            return this.objects.Where(ob => nameof(ob) == name).FirstOrDefault().Value;
        }
    }
}
