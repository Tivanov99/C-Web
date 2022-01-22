namespace BasicWebServer.Server
{
    using BasicWebServer.Server.Session;
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Routing;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HttpServer
    {
        private IPAddress _ipAddress;
        private int _port;
        private TcpListener listener;
        private readonly IRoutingTable _routingTable;

        public HttpServer(
            int port,
            string iPAddress,
            Action<IRoutingTable> routingTableConfiguration)
        {
            this._port = port;
            this._ipAddress = IPAddress.Parse(iPAddress);
            this.listener = new TcpListener(_ipAddress, _port);
            routingTableConfiguration(this._routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this(port, "127.0.0.1", routingTable)
        {

        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(8080, "127.0.0.1", routingTable)
        {

        }

        public async Task Start()
        {
            this.listener.Start();
            Console.WriteLine($"Server started on port {_port}...");
            Console.WriteLine("Listening for requests...");
            while (true)
            {
                _ = Task.Run(async () =>
                {
                    TcpClient connection = await this.listener
                        .AcceptTcpClientAsync();

                    NetworkStream networkStream = connection
                        .GetStream();

                    string requestString = await ReadRequest(networkStream);

                    Console.WriteLine(requestString);

                    IRequest request = PrepareRequest(requestString);

                    IResponse response = this._routingTable.MatchRequest(request);

                    AddSession(request, response);

                    await WriteResponse(networkStream, response);
                    connection.Close();
                });
            }
        }

        private async Task WriteResponse(NetworkStream networkStream, IResponse response)
        {
            string result = response.ToString();
            byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
            networkStream.Close();
        }
        private async Task<string> ReadRequest(NetworkStream stream)
        {
            int bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];
            StringBuilder requestBuilder = new StringBuilder();

            do
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, bufferLength);

                if (bytesRead > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (stream.DataAvailable);

            return requestBuilder.ToString();
        }

        private IRequest PrepareRequest(string queryString)
        {
            return new Request(queryString);
        }
        private void AddSession(IRequest request, IResponse response)
        {
            bool sessionExist = request.HttpSession
                .ContainsKey(Session.HttpSession.SessionCurrentDateKey);

            if (!sessionExist)
            {
                request.HttpSession[Session.HttpSession.SessionCurrentDateKey] =
                    DateTime.Now.ToString();
                response.Cookies
                    .Add(Session.HttpSession.SessionCookieName, request.HttpSession.Id);
            }
        }
    }
}
