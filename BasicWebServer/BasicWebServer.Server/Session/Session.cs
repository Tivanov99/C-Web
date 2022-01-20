namespace BasicWebServer.Server.Session
{
    using BasicWebServer.Server.Contracts;

    public class Session : ISession
    {
        public const string SessionCookieName = "MyWebServerSID";
        public const string SessionCurrentDateKey = "CurrentDate";
        public const string SessionUserKey = "AuthenticatedUserId";

        private Dictionary<string, string> data;

        public Session(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                this.Id = id;
            }
            data = new Dictionary<string, string>();
        }

        public string Key { get; private set; }

        public string Id { get; private set; }

        public string this[string key]
        {
            get => this.data[key];
            set => this.data[key] = value;
        }

        public bool ContainsKey(string key)
        => this.data.ContainsKey(key);

        public void Clear()
        => this.data.Clear();
    }
}
