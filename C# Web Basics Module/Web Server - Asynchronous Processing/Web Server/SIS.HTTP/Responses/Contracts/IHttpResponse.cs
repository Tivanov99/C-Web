namespace SIS.HTTP.Responses.Contracts
{
    using SIS.HTTP.Coocies;
    using SIS.HTTP.Coocies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }


        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; set; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();

        public void AddCookie(HttpCookie cookie);
    }
}
