namespace BasicWebServer.Server.Headers
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.Headers.Contracts;

    public class Header : IHeader
    {
        public const string ConteType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string Server = "Server";
        public const string ContentDisposition = "Content-Disposition";

        public Header(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
         => $"{this.Name}: {this.Value}";
    }
}
