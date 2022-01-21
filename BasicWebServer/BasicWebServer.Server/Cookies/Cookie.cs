namespace BasicWebServer.Server.Cookies
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }
        public override string ToString()
           => $"{this.Name}={this.Value}";
    }
}
