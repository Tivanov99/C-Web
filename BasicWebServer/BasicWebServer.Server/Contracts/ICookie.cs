using BasicWebServer.Server.Headers.Contracts;

namespace BasicWebServer.Server.Contracts
{
    public interface ICookie 
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
